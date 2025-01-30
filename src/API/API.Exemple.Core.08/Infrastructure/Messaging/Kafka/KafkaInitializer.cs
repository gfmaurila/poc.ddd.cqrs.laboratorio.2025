namespace API.Exemple1.Core._08.Infrastructure.Messaging.Kafka;

public class KafkaInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IKafkaProducer, KafkaProducer>();

        // Publish
        //services.AddScoped<INotificationProducer, NotificationProducer>();

        // Subscribe
        //services.AddHostedService<NotificationConsumer>();
    }
}