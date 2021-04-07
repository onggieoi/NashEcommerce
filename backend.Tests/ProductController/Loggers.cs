using backend.Controllers;
using backend.Repositories.ProductRepo;
using Microsoft.Extensions.Logging;
using Moq;

namespace backend.Tests.ProductController
{
    public static class Loggers
    {
        public static ILogger<ProductsController> ProductControllerLogger()
        {
            var mock = new Mock<ILogger<ProductsController>>();
            ILogger<ProductsController> logger = mock.Object;
            logger = Mock.Of<ILogger<ProductsController>>();

            return logger;
        }

        public static ILogger<ProductRepository> ProductRepositoryLogger()
        {
            var mock = new Mock<ILogger<ProductRepository>>();
            ILogger<ProductRepository> logger = mock.Object;
            logger = Mock.Of<ILogger<ProductRepository>>();

            return logger;
        }
    }
}