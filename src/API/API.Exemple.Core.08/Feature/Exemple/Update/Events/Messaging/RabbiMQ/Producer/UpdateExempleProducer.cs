using API.Exemple.Core._08.Feature.Domain.Common;
using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Producer;

public class UpdateExempleProducer : IUpdateExempleProducer
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UpdateExempleProducer> _logger;
    public UpdateExempleProducer(IMessageBusService messageBusService, IConfiguration configuration, ILogger<UpdateExempleProducer> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    public void PublishAsync(ExempleUpdateRabbitMQEvent enents)
    {
        string QUEUE_NAME = ExempleEventConstants.QueueExempleUpdate;
        var enentInfoJson = JsonSerializer.Serialize(enents);
        var enentInfoBytes = Encoding.UTF8.GetBytes(enentInfoJson);
        _messageBusService.Publish(QUEUE_NAME, enentInfoBytes);
    }
}
