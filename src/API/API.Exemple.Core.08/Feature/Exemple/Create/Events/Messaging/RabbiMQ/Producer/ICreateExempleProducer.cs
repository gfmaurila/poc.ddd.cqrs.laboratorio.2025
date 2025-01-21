using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

namespace API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Producer;

public interface ICreateExempleProducer
{
    void PublishAsync(ExempleCreateRabbitMQEvent events);
}
