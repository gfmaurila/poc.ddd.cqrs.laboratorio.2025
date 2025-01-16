using API.Auth.Infrastructure.Database;
using Common.Core.Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Auth.Extensions;

public static class InfrastructureExtensions
{
    public static void ApplyMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ModeloAppDbContext>();
            context.Database.Migrate();
            Console.WriteLine("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
            throw;
        }
    }

    //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddScoped<IUnitOfWork, UnitOfWork>();
    //    services.AddScoped<IBasketRepository, BasketRepository>();

    //    // Register AutoMapper
    //    services.AddAutoMapper(Assembly.GetExecutingAssembly());

    //    // Get Kafka configuration from appsettings.json
    //    var kafkaConfig = configuration.GetSection("Kafka");
    //    var bootstrapServers = kafkaConfig["BootstrapServers"];
    //    var defaultTopic = kafkaConfig["DefaultTopic"];

    //    // Register KafkaIntegrationEventPublisher
    //    services.AddSingleton<IIntegrationEventPublisher>(sp =>
    //    {
    //        return new KafkaIntegrationEventPublisher(bootstrapServers!, defaultTopic!);
    //    });

    //    // Register DbContext with a connection string
    //    services.AddDbContext<BasketAppDbContext>(options =>
    //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    //    return services;
    //}
}
