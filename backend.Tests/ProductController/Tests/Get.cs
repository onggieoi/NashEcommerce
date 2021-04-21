using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Exceptions;
using backend.Repositories.ProductRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;
using Xunit;

namespace backend.Tests.ProductController.Tests
{
    public class Get : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Get(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetAll_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();
            var product1 = NewDatas.NewProduct();
            var product2 = NewDatas.NewProduct();

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            await dbContext.Products.AddRangeAsync(product1, product2);
            product1.CategoryId = category.CategoryId;
            product2.CategoryId = category.CategoryId;
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, blobService, dbContext);
            var productController = new ProductsController(loggerController, productRepository);

            // Act
            var result = await productController.GetProducts(null);

            // Assert
            var getProductsResultType = Assert.IsType<ActionResult<IEnumerable<ProductRespone>>>(result);
            var getProductsResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotEmpty(getProductsResult.Value as IEnumerable<ProductRespone>);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        public async Task GetById_NotFound(int id)
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var productRepository = new ProductRepository(loggerRepository, mapper, blobService, dbContext);

            var productController = new ProductsController(loggerController, productRepository);

            // Assert & Act
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await productController.GetProduct(id);
            });
        }

        [Fact]
        public async Task GetById_Success()
        {
            // Arrange
            var loggerController = Loggers.ProductControllerLogger();
            var loggerRepository = Loggers.ProductRepositoryLogger();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();
            var product1 = NewDatas.NewProduct();
            var product2 = NewDatas.NewProduct();

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            await dbContext.Products.AddRangeAsync(product1, product2);
            product1.CategoryId = category.CategoryId;
            product2.CategoryId = category.CategoryId;
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRepository(loggerRepository, mapper, blobService, dbContext);

            var productController = new ProductsController(loggerController, productRepository);

            // Act
            var result = await productController.GetProduct(product1.ProductId);

            // Assert
            var productResult = Assert.IsType<OkObjectResult>(result.Result);
            var productValue = Assert.IsType<ProductRespone>(productResult.Value);

            Assert.Equal(product1.Name, productValue.Name);
            Assert.Equal(product1.Price, productValue.Price);
            Assert.Equal(product1.Description, productValue.Description);
            Assert.Equal(product1.Image, productValue.Image);
            Assert.Equal(product1.Rated, productValue.Rated);

            Assert.Equal(category.CategoryId, productValue.CategoryId);
            Assert.Equal(category.Name, productValue.CategoryName);
        }
    }
}