using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using backend.Configs;

namespace backend.Extensions.ServiceCollection
{
    public static class CorsRegister
    {
        public static void AddCorsOrigins(this IServiceCollection services, Dictionary<string, string> clientUrls)
        {
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