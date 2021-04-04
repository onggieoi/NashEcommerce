using Microsoft.Extensions.DependencyInjection;

namespace backend.Exceptions.ServiceCollection
{
    public static class AuthenticationRegister
    {
        public static void AddAuthenAuthor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddAuthentication()
                .AddLocalApi("Bearer", option =>
                {
                    option.ExpectedScope = "api";
                    // option.Events
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });
            });
        }
    }
}