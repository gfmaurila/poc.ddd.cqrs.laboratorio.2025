using API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Consumers;
using API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Exemple.Delete.Events.Messaging.RabbiMQ.Consumers;
using API.Exemple.Core._08.Feature.Exemple.Delete.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Consumers;
using API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Publish;
using API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Publish;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Subscribe;
using API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;
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
        services.AddScoped<ICreateExempleProducer, CreateExempleProducer>();
        services.AddScoped<IUpdateExempleProducer, UpdateExempleProducer>();
        services.AddScoped<IDeleteExempleProducer, DeleteExempleProducer>();

        // Subscribe - RabbiMQ
        services.AddHostedService<NotificationRabbiMQSubscribe>();
        services.AddHostedService<CreateExempleConsumer>();
        services.AddHostedService<UpdateExempleConsumer>();
        services.AddHostedService<DeleteExempleConsumer>();

        // Publish - Kafka
        services.AddScoped<INotificationKafkaPublish, NotificationKafkaPublish>();

        // Subscribe - Kafka
        services.AddHostedService<NotificationKafkaSubscribe>();
    }
}
