using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

namespace API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Producer;

public interface IUpdateExempleProducer
{
    void PublishAsync(ExempleUpdateRabbitMQEvent events);
}
