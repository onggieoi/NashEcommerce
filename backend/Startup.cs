using System.Reflection;
using backend.Extensions;
using backend.Extensions.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using backend.Constans;
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
            services.AddCorsOrigins(Configuration);
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.ConfigureSwagger();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors(AllowOrigins.OriginPolicy);
            app.UseMiddleware<ErrorHandler>();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
