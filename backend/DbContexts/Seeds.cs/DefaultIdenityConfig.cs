using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Configs;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.DbContexts.Seeds
{
    public static class DefaultIdentityConfig
    {
        public static async Task SeedAsync(ConfigurationDbContext context, IConfiguration config)
        {
            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = config["ClientUrl:Mvc"],
                ["Admin"] = config["ClientUrl:Admin"],
            };

            await context.Database.MigrateAsync();

            if (!context.Clients.Any())
            {
                foreach (var client in IdentityServerConfig.Clients(clientUrls))
                {
                    await context.Clients.AddAsync(client.ToEntity());
                }

                await context.SaveChangesAsync();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in IdentityServerConfig.Ids)
                {
                    await context.IdentityResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();

            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in IdentityServerConfig.Apis)
                {
                    await context.ApiResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in IdentityServerConfig.ApiScopes)
                {
                    await context.ApiScopes.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }
        }
    }
}