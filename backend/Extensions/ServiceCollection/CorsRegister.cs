using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using backend.Configs;
using Microsoft.Extensions.Configuration;

namespace backend.Extensions.ServiceCollection
{
    public static class CorsRegister
    {
        public static void AddCorsOrigins(this IServiceCollection services, IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = configuration["ClientUrl:Mvc"]
            };

            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigins.OriginPolicy,
                    builder =>
                    {
                        builder.WithOrigins(clientUrls["Mvc"])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}