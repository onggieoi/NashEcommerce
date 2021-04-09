using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Category;
using Xunit;

namespace backend.Tests.CategoryController.Tests
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
        public async Task Update_Success()
        {
            // Arrange
            var loggerController = Loggers.CategoryController();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var oldCategory = NewDatas.NewCategory();
            await dbContext.AddAsync(oldCategory);
            await dbContext.SaveChangesAsync();

            var newCategoryRequest = NewDatas.NewCategoryRequest();

            var categoryRepository = new CategoryRepository(mapper, dbContext);
            var catgoriesController = new CategoriesController(loggerController, categoryRepository);

            // Act
            var result = await catgoriesController.Update(oldCategory.CategoryId, newCategoryRequest);

            // Assert
            var createdCategoryResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<CategoryRespone>(createdCategoryResult.Value);

            Assert.Equal(oldCategory.Name, resultValue.Name);
            Assert.Equal(oldCategory.Description, resultValue.Description);
            Assert.Equal(oldCategory.Image, resultValue.Image);

            Assert.Equal(oldCategory.Name, newCategoryRequest.Name);
            Assert.Equal(oldCategory.Description, newCategoryRequest.Description);
            Assert.Equal(oldCategory.Image, newCategoryRequest.Image);
        }
    }
}