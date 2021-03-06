using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using backend.Constans;
using Microsoft.Extensions.Configuration;

namespace backend.Extensions.ServiceCollection
{
    public static class CorsRegister
    {
        public static void AddCorsOrigins(this IServiceCollection services, IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = configuration["ClientUrl:Mvc"],
                ["Admin"] = configuration["ClientUrl:Admin"],
            };

            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigins.OriginPolicy,
                    builder =>
                    {
                        builder.WithOrigins(clientUrls["Mvc"], clientUrls["Admin"])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}