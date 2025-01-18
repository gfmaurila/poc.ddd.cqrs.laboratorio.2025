using API.Exemple.Core._08.Infrastructure.Auth;
using API.Exemple.Core._08.Infrastructure.Database;
using API.Exemple.Core._08.Infrastructure.Database.Repositories;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;
using API.Exemple.Core._08.Infrastructure.Redis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Exemple.Core._08.Extensions;

public static class InfrastructureExtensions
{
    public static async Task MigrateAsync(this WebApplication app)
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        await using var writeDbContext = serviceScope.ServiceProvider.GetRequiredService<ExempleAppDbContext>();
        try
        {
            await app.MigrateDbContextAsync(writeDbContext);
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "Ocorreu uma exceção ao iniciar a aplicação: {Message}", ex.Message); throw;
        }
    }

    private static async Task MigrateDbContextAsync<TContext>(this WebApplication app, TContext context)
        where TContext : DbContext
    {
        var dbName = context.Database.GetDbConnection().Database;

        app.Logger.LogInformation("----- {DbName}: {DbConnection}", dbName, context.Database.GetConnectionString());
        app.Logger.LogInformation("----- {DbName}: Verificando se existem migrações pendentes...", dbName);

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            app.Logger.LogInformation("----- {DbName}: Criando e migrando a base de dados...", dbName);

            await context.Database.MigrateAsync();

            app.Logger.LogInformation("----- {DbName}: Base de dados criada e migrada com sucesso!", dbName);
        }
        else
        {
            app.Logger.LogInformation("----- {DbName}: Migrações estão em dia.", dbName);
        }
    }

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
        DistributedCacheInitializer.Initialize(services, configuration);

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
