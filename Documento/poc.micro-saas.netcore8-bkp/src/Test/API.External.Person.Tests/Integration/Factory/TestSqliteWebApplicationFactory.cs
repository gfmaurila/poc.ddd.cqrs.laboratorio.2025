using API.External.Person.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Exemple.Core.Tests.Integration.Factory;

public class TestSqliteWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        builder.UseEnvironment("Test");

        builder.ConfigureServices(services =>
        {
            // Remove the existing context configuration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PersonAppDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            // Add SQLite In-Memory context for testing
            services.AddDbContext<PersonAppDbContext>(options =>
            {
                options.UseSqlite("DataSource=:memory:"); // SQLite In-Memory
            });

            // Build the service provider
            var sp = services.BuildServiceProvider();

            // Create the schema in the SQLite In-Memory test database
            using var scope = sp.CreateScope();
            var appContext = scope.ServiceProvider.GetRequiredService<PersonAppDbContext>();

            appContext.Database.OpenConnection(); // Necessário para SQLite In-Memory
            appContext.Database.EnsureCreated();
        });
    }
}
