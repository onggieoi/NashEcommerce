using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.ProductRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;
using Xunit;

namespace backend.Tests.ProductController.Tests
{
    public class Update : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Update(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task UpdateProduct_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var oldCategory = NewDatas.NewCategory();
            var newCategory = NewDatas.NewCategory();
            await dbContext.Categories.AddRangeAsync(oldCategory, newCategory);
            await dbContext.SaveChangesAsync();

            var product = NewDatas.NewProduct();
            product.CategoryId = oldCategory.CategoryId;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, dbContext);

            var productRequest = NewDatas.NewProductRequest();
            productRequest.CategoryId = newCategory.CategoryId;

            // Act
            var productController = new ProductsController(loggerController, productRepository);
            var result = await productController.UpdateProduct(product.ProductId, productRequest);

            // Assert
            var updatedResult = Assert.IsType<OkObjectResult>(result.Result);
            var updatedValue = Assert.IsType<ProductRespone>(updatedResult.Value);

            Assert.Equal(product.Name, updatedValue.Name);
            Assert.Equal(product.Price, updatedValue.Price);
            Assert.Equal(product.Description, updatedValue.Description);
            Assert.Equal(product.Image, updatedValue.Image);
            Assert.Equal(product.Rated, updatedValue.Rated);

            Assert.Equal(newCategory.CategoryId, updatedValue.CategoryId);
            Assert.Equal(newCategory.Name, updatedValue.CategoryName);
        }
    }
}