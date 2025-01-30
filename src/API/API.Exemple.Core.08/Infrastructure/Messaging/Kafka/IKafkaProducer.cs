namespace API.Exemple1.Core._08.Infrastructure.Messaging.Kafka;

public interface IKafkaProducer
{
    void PublishAsync<T>(T eventMessage) where T : class;
}
