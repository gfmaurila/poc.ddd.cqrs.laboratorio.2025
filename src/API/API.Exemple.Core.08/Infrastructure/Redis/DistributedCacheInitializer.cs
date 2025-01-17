using Common.Core._08.Interface;
using Common.Core._08.Model;
using Common.Core._08.Service;
using StackExchange.Redis;

namespace API.Exemple.Core._08.Infrastructure.Redis;

public class DistributedCacheInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IConfiguration>(provider => configuration);
        services.AddSingleton<RedisConnection>();
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("CacheConnection")));
        services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));
    }

}
