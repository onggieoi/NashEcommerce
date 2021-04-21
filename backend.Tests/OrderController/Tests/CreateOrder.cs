using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.OrderCartRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;
using Xunit;

namespace backend.Tests.OrderController.Tests
{
    public class Create : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Create(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task CreateOrder_Success()
        {
            // Arrange
            var loggerRepository = Loggers.OrderRepositoryLogger();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();
            var user = NewDatas.NewUser();

            await dbContext.Categories.AddAsync(category);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product1 = NewDatas.NewProduct();
            product1.CategoryId = category.CategoryId;

            var product2 = NewDatas.NewProduct();
            product2.CategoryId = category.CategoryId;

            await dbContext.Products.AddRangeAsync(product1, product2);
            await dbContext.SaveChangesAsync();

            var contextAccessor = ContextAccesser.mockHttpAccessor(user.Id);

            var orderCartRepository = new OrderCartRepository(loggerRepository, contextAccessor, mapper, dbContext);

            var orderRequest = new List<CartOrderRequest> {
                new CartOrderRequest {
                    ProductId = product1.ProductId,
                    Quantity = 3,
                },
                new CartOrderRequest {
                    ProductId = product2.ProductId,
                    Quantity = 2,
                },
            };

            // Act
            var orderController = new OrdersController(orderCartRepository);
            var result = await orderController.CreateOrder(orderRequest);

            // Assert
            var orderResultType = Assert.IsType<ActionResult<IEnumerable<CartOrderRespone>>>(result);
            var getOrdersResultValue = Assert.IsType<CreatedResult>(result.Result);

            var ordersValue = getOrdersResultValue.Value as List<CartOrderRespone>;
            Assert.NotEmpty(ordersValue);

            var totalPriceReq = (product1.Price * orderRequest[0].Quantity) + (product2.Price * orderRequest[1].Quantity);

            var totalPriceRes = 0;
            ordersValue.ForEach(order => totalPriceRes += order.Product.Price * order.Quantity);

            Assert.Equal(totalPriceReq, totalPriceRes);
        }
    }
}