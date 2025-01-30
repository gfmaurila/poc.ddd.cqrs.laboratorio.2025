namespace API.Exemple1.Core._08.Infrastructure.Messaging;

public class MessagingConsts
{
    // RabbiMQ
    public const string Hostname = "RabbitMQ:Hostname";
    public const string Port = "RabbitMQ:Port";
    public const string Username = "RabbitMQ:Username";
    public const string Password = "RabbitMQ:Password";
    public const string VirtualHost = "RabbitMQ:VirtualHost";

    // Kafka
    public const string HostnameKafka = "Kafka:BootstrapServers";
    public const string HostnameKafkaDefaultTopic = "Kafka:DefaultTopic";
}
