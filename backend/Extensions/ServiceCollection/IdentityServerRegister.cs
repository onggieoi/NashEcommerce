using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using backend.DbContexts;
using backend.Configs;

namespace backend.Extensions.ServiceCollection
{
    public static class IdentityServerRegister
    {
        public static void AddIdentityServerCustom(this IServiceCollection services,
            IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = configuration["ClientUrl:Mvc"],
                ["Admin"] = configuration["ClientUrl:Admin"],
            };

            var connectionString = configuration.GetConnectionString("ApplicationConnection");

            var assembly = typeof(Startup).Assembly.GetName().Name;

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                // config.Cookie.Name = "server";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddAspNetIdentity<IdentityUser>()
                // .AddConfigurationStore(options =>
                // {
                //     options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                //         sql => sql.MigrationsAssembly(assembly));
                // })
                // .AddOperationalStore(options =>
                // {
                //     options.ConfigureDbContext = b =>
                //         b.UseSqlServer(connectionString, sql =>
                //             sql.MigrationsAssembly(assembly));
                // })
                .AddProfileService<ProfileService>()
                .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryClients(IdentityServerConfig.Clients(clientUrls))
                .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
                .AddDeveloperSigningCredential();
            // .AddTestUsers(TestUsers.Users)
        }
    }
}