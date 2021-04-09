using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Category;
using Xunit;

namespace backend.Tests.CategoryController.Tests
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
            var loggerController = Loggers.CategoryController();

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category1 = NewDatas.NewCategory();
            var category2 = NewDatas.NewCategory();
            var category3 = NewDatas.NewCategory();

            await dbContext.AddRangeAsync(category1, category2, category3);
            await dbContext.SaveChangesAsync();

            var categoryRepository = new CategoryRepository(mapper, dbContext);
            var catgoriesController = new CategoriesController(loggerController, categoryRepository);

            // Act
            var result = await catgoriesController.GetAll();

            // Assert
            var getCategoriesResultType = Assert.IsType<ActionResult<IEnumerable<CategoryRespone>>>(result);
            var getCategoriesResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.NotEmpty(getCategoriesResult.Value as IEnumerable<CategoryRespone>);
        }
    }
}