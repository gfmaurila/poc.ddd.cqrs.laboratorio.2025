using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple1.Core._08.Infrastructure.Messaging.Kafka;

public class KafkaProducer : IKafkaProducer
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<KafkaProducer> _logger;

    public KafkaProducer(IMessageBusService messageBusService, IConfiguration configuration, ILogger<KafkaProducer> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    public void PublishAsync<T>(T eventMessage) where T : class
    {
        try
        {
            // Obtenha o nome do tópico Kafka do appsettings.json
            string topic = _configuration.GetValue<string>("Kafka:DefaultTopic");

            // Serialize o evento em JSON
            var messageJson = JsonSerializer.Serialize(eventMessage);
            var messageBytes = Encoding.UTF8.GetBytes(messageJson);

            // Publica a mensagem no Kafka usando o serviço de mensageria
            _messageBusService.Publish(topic, messageBytes);

            _logger.LogInformation("Mensagem publicada no Kafka no tópico {Topic}: {Message}", topic, messageJson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao publicar mensagem no Kafka: {Message}", ex.Message);
            throw;
        }
    }
}
