using backend.Repositories.OrderCartRepo;
using Microsoft.Extensions.Logging;
using Moq;

namespace backend.Tests.OrderController
{
    public static class Loggers
    {
        public static ILogger<OrderCartRepository> OrderRepositoryLogger()
        {
            var mock = new Mock<ILogger<OrderCartRepository>>();
            ILogger<OrderCartRepository> logger = mock.Object;

            logger = Mock.Of<ILogger<OrderCartRepository>>();

            return logger;
        }
    }
}