using Microsoft.Extensions.DependencyInjection;
using backend.Repositories.ProductRepo;
using backend.Repositories.CategoryRepo;
using backend.Repositories.OrderCartRepo;
using backend.Repositories.RatingRepo;
using backend.Repositories.CustomerRepo;

namespace backend.Extensions.ServiceCollection
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderCartRepository, OrderCartRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}