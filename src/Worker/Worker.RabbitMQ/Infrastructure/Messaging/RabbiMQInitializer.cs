using Worker.RabbitMQ.Infrastructure.Messaging.API.Exemple.Core._08;
using Worker.RabbitMQ.Infrastructure.Messaging.ExternalEmail;

namespace Worker.RabbitMQ.Infrastructure.Messaging;

public class RabbiMQInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        // Subscribe
        services.AddHostedService<NotificationConsumer>();
        services.AddHostedService<CreateExempleConsumer>();
        services.AddHostedService<UpdateExempleConsumer>();
        services.AddHostedService<DeleteExempleConsumer>();
    }
}
