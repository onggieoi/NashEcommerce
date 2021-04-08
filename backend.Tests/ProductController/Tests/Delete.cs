using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.ProductRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;
using Xunit;

namespace backend.Tests.ProductController.Tests
{
    public class Delete : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Delete(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();
            await dbContext.Categories.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var product = NewDatas.NewProduct();
            product.CategoryId = category.CategoryId;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, dbContext);
            var productController = new ProductsController(loggerController, productRepository);

            // Act
            var result = await productController.RemoveProduct(product.ProductId);

            // Assert
            var deletedResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedResultValue = Assert.IsType<ProductRespone>(deletedResult.Value);

            Assert.Equal(product.Name, deletedResultValue.Name);
            Assert.Equal(product.Price, deletedResultValue.Price);
            Assert.Equal(product.Description, deletedResultValue.Description);
            Assert.Equal(product.Image, deletedResultValue.Image);
            Assert.Equal(product.Rated, deletedResultValue.Rated);

            Assert.Equal(category.CategoryId, deletedResultValue.CategoryId);
            Assert.Equal(category.Name, deletedResultValue.CategoryName);
        }
    }
}