using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Exceptions;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Category;
using Xunit;

namespace backend.Tests.CategoryController.Tests
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
            var loggerController = Loggers.CategoryController();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = NewDatas.NewCategory();

            await dbContext.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var categoryRepository = new CategoryRepository(mapper, blobService, dbContext);
            var catgoriesController = new CategoriesController(loggerController, categoryRepository);

            // Act
            var result = await catgoriesController.Delete(category.CategoryId);

            // Assert
            var createdCategoryResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<CategoryRespone>(createdCategoryResult.Value);

            Assert.Equal(category.Name, resultValue.Name);
            Assert.Equal(category.Description, resultValue.Description);
            Assert.Equal(category.Image, resultValue.Image);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await catgoriesController.GetById(resultValue.CategoryId);
            });
        }
    }
}