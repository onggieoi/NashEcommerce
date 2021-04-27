using System;
using System.Linq;
using System.Threading.Tasks;
using backend.DbContexts;
using backend.DbContexts.Seeds;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                // uncomment to write to Azure diagnostics stream
                //.WriteTo.File(
                //    @"D:\home\LogFiles\Application\identityserver.txt",
                //    fileSizeLimitBytes: 1_000_000,
                //    rollOnFileSizeLimit: true,
                //    shared: true,
                //    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                    theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    var idenityServerContext = services.GetRequiredService<ConfigurationDbContext>();
                    var config = services.GetRequiredService<IConfiguration>();

                    if (!dbContext.Roles.Any())
                    {
                        Log.Information("Started Seeding Default Roles and Users");

                        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                        await DefaultRoles.SeedAsync(userManager, roleManager);
                        await DefaultAdminUser.SeedAsync(userManager, roleManager);
                    }

                    if (!idenityServerContext.Clients.Any())
                    {
                        Log.Information("Started Seeding Default Identity Server");

                        await DefaultIdentityConfig.SeedAsync(idenityServerContext, config);
                    }

                    if (!dbContext.Categories.Any())
                    {
                        Log.Information("Started Seeding Default Data");

                        await DefaultData.SeedAsync(dbContext);
                    }

                    Log.Information("Application Starting");
                }

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder =>
                    loggingBuilder.Configure(options =>
                        options.ActivityTrackingOptions = ActivityTrackingOptions.TraceId | ActivityTrackingOptions.SpanId)
                .AddSimpleConsole(op => op.IncludeScopes = true))
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
