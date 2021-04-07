using System.Threading.Tasks;
using AutoMapper;
using backend.Controllers;
using backend.Models;
using backend.Repositories.ProductRepo;
using backend.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ViewModelShare.Product;
using Xunit;

namespace backend.Tests.ProductController
{
    public class ProductControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ProductControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostProduct_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();

            await dbContext.Categories.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, dbContext);

            var productRequest = NewDatas.NewProductRequest();
            productRequest.CategoryId = category.CategoryId;

            // Act
            var productController = new ProductsController(loggerController, productRepository);
            var result = await productController.CreateProduct(productRequest);

            // Assert
            var createdAtActionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ProductRespone>(createdAtActionResult.Value);

            Assert.Equal("Test", returnValue.Name);
            Assert.Equal(100, returnValue.Price);
            Assert.Equal("Description", returnValue.Description);
        }
    }
}