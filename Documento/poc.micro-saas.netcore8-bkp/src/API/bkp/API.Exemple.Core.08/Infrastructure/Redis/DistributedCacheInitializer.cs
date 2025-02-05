using Common.Core._08.Interface;
using Common.Core._08.Model;
using Common.Core._08.Service;
using StackExchange.Redis;

namespace API.Exemple.Core._08.Infrastructure.Redis;

public class DistributedCacheInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {

        //services.AddSingleton<IConfiguration>(provider => configuration);
        //services.AddSingleton<RedisConnection>();
        //services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("CacheConnection")));
        //services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));
        //services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));

        services.AddSingleton<IConfiguration>(provider => configuration);
        services.AddSingleton<RedisConnection>();
        services.AddSingleton<IConnectionMultiplexer>(provider =>
        {
            var config = ConfigurationOptions.Parse(configuration.GetConnectionString("CacheConnection"));
            config.AbortOnConnectFail = false; // Desativa falha imediata
            config.ConnectRetry = 5; // Tentativas de reconexão
            config.ConnectTimeout = 10000; // Timeout de conexão (10s)
            config.SyncTimeout = 10000; // Timeout para operações sincronizadas
            config.AllowAdmin = true; // Permite comandos administrativos
            config.CommandMap = CommandMap.Default; // Comandos padrão
            return ConnectionMultiplexer.Connect(config);
        });
        services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));
    }

}
