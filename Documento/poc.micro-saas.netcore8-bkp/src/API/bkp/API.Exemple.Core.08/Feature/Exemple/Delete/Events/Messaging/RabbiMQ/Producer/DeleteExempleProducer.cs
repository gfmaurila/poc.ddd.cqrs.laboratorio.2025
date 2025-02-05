using API.Exemple.Core._08.Feature.Domain.Common;
using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple.Core._08.Feature.Exemple.Delete.Events.Messaging.RabbiMQ.Producer;

public class DeleteExempleProducer : IDeleteExempleProducer
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<DeleteExempleProducer> _logger;
    public DeleteExempleProducer(IMessageBusService messageBusService, IConfiguration configuration, ILogger<DeleteExempleProducer> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    public void PublishAsync(ExempleDeleteRabbitMQEvent enents)
    {
        string QUEUE_NAME = ExempleEventConstants.QueueExempleDelete;
        var enentInfoJson = JsonSerializer.Serialize(enents);
        var enentInfoBytes = Encoding.UTF8.GetBytes(enentInfoJson);
        _messageBusService.Publish(QUEUE_NAME, enentInfoBytes);
    }
}
