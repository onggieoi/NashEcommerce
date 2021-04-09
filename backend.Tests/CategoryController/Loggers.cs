using backend.Controllers;
using backend.Repositories.CategoryRepo;
using Microsoft.Extensions.Logging;
using Moq;

namespace backend.Tests.CategoryController
{
    public static class Loggers
    {
        public static ILogger<CategoriesController> CategoryController()
        {
            var mock = new Mock<ILogger<CategoriesController>>();
            ILogger<CategoriesController> logger = mock.Object;
            logger = Mock.Of<ILogger<CategoriesController>>();

            return logger;
        }
    }
}