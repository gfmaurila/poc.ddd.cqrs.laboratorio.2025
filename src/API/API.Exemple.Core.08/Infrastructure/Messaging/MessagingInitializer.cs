using API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Publish;
using API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Publish;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Subscribe;
using API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Exemple.Create.Events.Messaging.Publish;
using API.Exemple1.Core._08.Feature.Exemple.Create.Events.Messaging.Subscribe;
using API.Exemple1.Core._08.Feature.Exemple.Delete.Events.Messaging.Publish;
using API.Exemple1.Core._08.Feature.Exemple.Delete.Events.Messaging.Subscribe;
using API.Exemple1.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Publish;
using API.Exemple1.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Subscribe;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Service;
using Common.Core._08.Interface;

namespace API.Exemple1.Core._08.Infrastructure.Messaging;

public class MessagingInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();
        services.AddScoped<INotificationService, NotificationService>();

        // Publish - RabbiMQ
        services.AddScoped<INotificationRabbiMQPublish, NotificationRabbiMQPublish>();
        services.AddScoped<ICreateExemplePublish, CreateExemplePublish>();
        services.AddScoped<IUpdateExemplePublish, UpdateExemplePublish>();
        services.AddScoped<IDeleteExemplePublish, DeleteExemplePublish>();

        // Subscribe - RabbiMQ
        services.AddHostedService<NotificationRabbiMQSubscribe>();
        services.AddHostedService<CreateExempleSubscribe>();
        services.AddHostedService<UpdateExempleSubscribe>();
        services.AddHostedService<DeleteExempleSubscribe>();

        // Publish - Kafka
        services.AddScoped<INotificationKafkaPublish, NotificationKafkaPublish>();

        // Subscribe - Kafka
        services.AddHostedService<NotificationKafkaSubscribe>();
    }
}
