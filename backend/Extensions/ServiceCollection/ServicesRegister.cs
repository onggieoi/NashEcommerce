using Azure.Storage.Blobs;
using backend.DbContexts;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions.ServiceCollection
{
    public static class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBlobService, BlobService>();
        }
    }
}