using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Common.Core._08.Kafka;

public class KafkaConsumer : IKafkaConsumer
{
    private readonly ILogger<KafkaConsumer> _logger;
    private readonly KafkaConsumerConfig _config;

    public KafkaConsumer(KafkaConsumerConfig config, ILogger<KafkaConsumer> logger)
    {
        _logger = logger;
        _config = config;
    }

    public async Task ConsumeAsync(IEnumerable<string> topics, string groupId, Func<string, Task> messageHandler, CancellationToken cancellationToken)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = _config.BootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = _config.AutoOffsetReset,
            EnableAutoCommit = _config.EnableAutoCommit,
            SessionTimeoutMs = _config.SessionTimeoutMs,
            MaxPollIntervalMs = _config.MaxPollIntervalMs
        };

        using var consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        consumer.Subscribe(topics);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);

                if (consumeResult != null)
                {
                    _logger.LogInformation($"Received message from {consumeResult.Topic}: {consumeResult.Message.Value}");
                    await messageHandler(consumeResult.Message.Value);
                    consumer.Commit(consumeResult);
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Kafka Consumer stopped.");
        }
        finally
        {
            consumer.Close();
        }
    }
}
