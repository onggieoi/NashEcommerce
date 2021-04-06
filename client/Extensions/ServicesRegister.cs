using client.Services.Cart;
using Microsoft.Extensions.DependencyInjection;

namespace client.Extensions
{
    public static class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICartService, CartService>();
        }
    }
}