using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ.Producer;
using API.Exemple.Core._08.Feature.Notification;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Create.Events.Messaging.RabbiMQ;

public class ExempleCreateRabbitMQEventHandler : INotificationHandler<ExempleCreateRabbitMQEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ICreateExempleProducer _producer;


    public ExempleCreateRabbitMQEventHandler(IMediator mediator, IConfiguration configuration, ICreateExempleProducer producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    public async Task Handle(ExempleCreateRabbitMQEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ - Acessando serviços externos.
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);

        // RabbiMQ - publica sem acessar nenhum serviços externo
        _producer.PublishAsync(request);
    }

    private async Task EmailRabbiMQAppCommand(ExempleCreateRabbitMQEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.Email, _configuration.GetValue<string>(ExternalApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }

    private async Task WhatsAppRabbiMQAppCommand(ExempleCreateRabbitMQEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.WhatsApp, _configuration.GetValue<string>(ExternalApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }
}
