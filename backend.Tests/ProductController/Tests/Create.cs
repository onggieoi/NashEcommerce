using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.ProductRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;
using Xunit;

namespace backend.Tests.ProductController.Tests
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
        public async Task CreateProduct_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();

            await dbContext.Categories.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, blobService, dbContext);

            var productRequest = NewDatas.NewProductRequest();
            productRequest.CategoryId = category.CategoryId;

            // Act
            var productController = new ProductsController(loggerController, productRepository);
            var result = await productController.CreateProduct(productRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<ProductRespone>(createdResult.Value);

            Assert.Equal(productRequest.Name, returnValue.Name);
            Assert.Equal(productRequest.Price, returnValue.Price);
            Assert.Equal(productRequest.Description, returnValue.Description);
            Assert.Equal(productRequest.Image, returnValue.Image);
            Assert.Equal(0, returnValue.Rated);
            Assert.Equal(category.CategoryId, returnValue.CategoryId);
            Assert.Equal(category.Name, returnValue.CategoryName);
        }
    }
}