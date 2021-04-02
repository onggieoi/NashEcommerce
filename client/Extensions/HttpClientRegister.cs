using System;
using System.Net.Http;
using client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace client.Extensions
{
    public static class HttpCLientRegister
    {
        public static void AddRegisterHttpClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient();

            var configureClient = new Action<IServiceProvider, HttpClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(config["BackEndUrl"]);
            });

            services.AddHttpClient<IHttpClientService, HttpClientService>(configureClient);
        }
    }
}