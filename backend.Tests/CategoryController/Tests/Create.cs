using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Category;
using Xunit;

namespace backend.Tests.CategoryController.Tests
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
        public async Task Create_Success()
        {
            // Arrange
            var loggerController = Loggers.CategoryController();
            var blobService = BlobService.BlobServiceUpload();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var categoryRequest = NewDatas.NewCategoryRequest();

            var categoryRepository = new CategoryRepository(mapper, blobService, dbContext);
            var catgoriesController = new CategoriesController(loggerController, categoryRepository);

            // Act
            var result = await catgoriesController.Create(categoryRequest);

            // Assert
            var createdCategoryResult = Assert.IsType<CreatedResult>(result.Result);
            var resultValue = Assert.IsType<CategoryRespone>(createdCategoryResult.Value);

            Assert.Equal(categoryRequest.Name, resultValue.Name);
            Assert.Equal(categoryRequest.Description, resultValue.Description);
            Assert.Equal(categoryRequest.Image, resultValue.Image);
        }
    }
}