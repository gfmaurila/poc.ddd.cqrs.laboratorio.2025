using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

namespace API.Exemple.Core._08.Feature.Exemple.Delete.Events.Messaging.RabbiMQ.Producer;

public interface IDeleteExempleProducer
{
    void PublishAsync(ExempleDeleteRabbitMQEvent events);
}
