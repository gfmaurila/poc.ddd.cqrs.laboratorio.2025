using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Consumers;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Service;
using Common.Core._08.Interface;

namespace API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;

public class RabbiMQInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();
        services.AddScoped<INotificationService, NotificationService>();

        // Publish
        services.AddScoped<INotificationProducer, NotificationProducer>();

        // Subscribe
        services.AddHostedService<NotificationConsumer>();
    }
}
