using API.Exemple.Core._08.Infrastructure.Auth;
using API.Exemple.Core._08.Infrastructure.Database;
using API.Exemple.Core._08.Infrastructure.Database.Repositories;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Exemple.Core._08.Extensions;

public static class InfrastructureExtensions
{
    public static void ApplyMigrations(this IHost app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ExempleAppDbContext>();
                context.Database.Migrate();
                Console.WriteLine("Database migrations applied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
                throw;
            }
        }
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Repository
        services.AddScoped<IExempleRepository, ExempleRepository>();

        // Redis
        //DistributedCacheInitializer.Initialize(services, configuration);

        // Services
        CoreInitializer.Initialize(services);

        // Register AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // RabbitMQ
        RabbiMQInitializer.Initialize(services);

        // Get Kafka configuration from appsettings.json
        var kafkaConfig = configuration.GetSection("Kafka");
        var bootstrapServers = kafkaConfig["BootstrapServers"];
        var defaultTopic = kafkaConfig["DefaultTopic"];

        // Register KafkaIntegrationEventPublisher
        //services.AddSingleton<IIntegrationEventPublisher>(sp =>
        //{
        //    return new KafkaIntegrationEventPublisher(bootstrapServers!, defaultTopic!);
        //});

        // Register DbContext with a connection string
        services.AddDbContext<ExempleAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        return services;
    }
}
