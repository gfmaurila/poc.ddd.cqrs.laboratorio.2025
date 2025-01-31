using Confluent.Kafka;

namespace Common.Core._08.Kafka;

public class KafkaConsumerConfig
{
    public string BootstrapServers { get; set; }
    public string GroupId { get; set; }
    public AutoOffsetReset AutoOffsetReset { get; set; } = AutoOffsetReset.Earliest;
    public bool EnableAutoCommit { get; set; } = false;
    public int SessionTimeoutMs { get; set; } = 10000;
    public int MaxPollIntervalMs { get; set; } = 300000;
}
