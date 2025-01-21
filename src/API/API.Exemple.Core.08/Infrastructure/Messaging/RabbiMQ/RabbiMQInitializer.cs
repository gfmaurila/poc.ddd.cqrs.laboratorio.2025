using API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Exemple.Delete.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Producer;
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
        services.AddScoped<ICreateExempleProducer, CreateExempleProducer>();
        services.AddScoped<IUpdateExempleProducer, UpdateExempleProducer>();
        services.AddScoped<IDeleteExempleProducer, DeleteExempleProducer>();

        // Subscribe
        services.AddHostedService<NotificationConsumer>();
    }
}
