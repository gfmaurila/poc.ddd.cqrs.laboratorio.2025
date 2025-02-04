using API.External.Person.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Exemple.Core.Tests.Integration.Factory;


public class TestInMemoryWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
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

            // Add In-Memory context for testing
            services.AddDbContext<PersonAppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // Build the service provider
            var sp = services.BuildServiceProvider();

            // Create the schema in the In-Memory test database
            using var scope = sp.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<PersonAppDbContext>();
            appContext.Database.EnsureCreated();
        });
    }
}
