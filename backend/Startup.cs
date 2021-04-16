using System.Linq;
using System.Reflection;
using backend.Extensions;
using backend.Extensions.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using backend.Configs;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using backend.Middlewares;
using backend.Exceptions.ServiceCollection;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContext(Configuration);
            // services.AddCorsOrigins(Configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddIdentityServerCustom(Configuration);
            services.AddServices();
            services.AddRepositories();
            services.AddAuthenAuthor();
            services.AddSwagger();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.ConfigureSwagger();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            // app.UseCors(AllowOrigins.OriginPolicy);
            app.UseMiddleware<ErrorHandler>();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = Configuration["ClientUrl:Mvc"],
                ["Admin"] = Configuration["ClientUrl:Admin"],
            };

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in IdentityServerConfig.Clients(clientUrls))
                    {
                        context.Clients.Add(client.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in IdentityServerConfig.Ids)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }

                    context.SaveChanges();

                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in IdentityServerConfig.Apis)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in IdentityServerConfig.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
