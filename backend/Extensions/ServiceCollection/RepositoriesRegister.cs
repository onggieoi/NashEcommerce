using Microsoft.Extensions.DependencyInjection;
using backend.Repositories.ProductRepo;

namespace backend.Extensions.ServiceCollection
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}