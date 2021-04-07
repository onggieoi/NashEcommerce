using System;
using System.Reflection;
using backend.DbContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Tests
{
    public class SqliteInMemoryFixture : IDisposable
    {
        private IServiceScope _serviceScope;
        private SqliteConnection _connection;

        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceScope == null)
                {
                    _serviceScope = ConfigureServices(new ServiceCollection())
                        .BuildServiceProvider()
                        .CreateScope();
                }

                return _serviceScope.ServiceProvider;
            }
        }

        public virtual ApplicationDbContext Context
            => ServiceProvider.GetRequiredService<ApplicationDbContext>();

        public virtual void CreateDatabase()
        {
            Dispose();
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            Context.Database.EnsureCreated();
        }

        public virtual void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            _serviceScope?.Dispose();
            _serviceScope = null;
        }

        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(b =>
                b.UseSqlite(_connection));

            // services.AddAutoMapper(backend.Assembly.GetExecutingAssembly());

            return services;
        }
    }
}