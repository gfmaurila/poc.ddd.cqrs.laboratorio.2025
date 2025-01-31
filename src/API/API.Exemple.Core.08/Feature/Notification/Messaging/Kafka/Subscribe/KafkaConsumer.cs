using API.Exemple1.Core._08.Infrastructure.Messaging;
using Common.Core._08.Kafka;
using Confluent.Kafka;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;

public class KafkaConsumer : IKafkaConsumer
{
    private readonly ILogger<KafkaConsumer> _logger;
    private readonly IConsumer<Null, string> _consumer;

    public KafkaConsumer(IConfiguration configuration, ILogger<KafkaConsumer> logger)
    {
        _logger = logger;

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = configuration.GetValue<string>(MessagingConsts.HostnameKafka),
            GroupId = "notification-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
    }

    public async Task ConsumeAsync(string topic, Func<string, Task> messageHandler, CancellationToken cancellationToken)
    {
        _consumer.Subscribe(topic);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(cancellationToken);

                if (consumeResult != null)
                {
                    _logger.LogInformation($"Received message: {consumeResult.Message.Value}");
                    await messageHandler(consumeResult.Message.Value);
                    _consumer.Commit(consumeResult);
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Kafka Consumer stopped.");
        }
        finally
        {
            _consumer.Close();
        }
    }
}
