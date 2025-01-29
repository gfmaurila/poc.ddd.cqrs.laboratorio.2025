using API.Exemple.Core._08.Feature.Domain.Common;
using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Producer;

public class CreateExempleProducer : ICreateExempleProducer
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CreateExempleProducer> _logger;
    public CreateExempleProducer(IMessageBusService messageBusService, IConfiguration configuration, ILogger<CreateExempleProducer> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    public void PublishAsync(ExempleCreateRabbitMQEvent enents)
    {
        string QUEUE_NAME = ExempleEventConstants.QueueExempleCreate;
        var enentInfoJson = JsonSerializer.Serialize(enents);
        var enentInfoBytes = Encoding.UTF8.GetBytes(enentInfoJson);
        _messageBusService.Publish(QUEUE_NAME, enentInfoBytes);
    }
}
