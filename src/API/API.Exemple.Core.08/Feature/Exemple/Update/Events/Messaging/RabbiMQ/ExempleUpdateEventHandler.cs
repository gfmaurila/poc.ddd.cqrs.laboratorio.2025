using API.Exemple.Core._08.Feature.Notification;
using API.Exemple.Core._08.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ.Publish;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ;

public class ExempleUpdateEventHandler : INotificationHandler<ExempleUpdateEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IUpdateExemplePublish _producer;


    public ExempleUpdateEventHandler(IMediator mediator, IConfiguration configuration, IUpdateExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    public async Task Handle(ExempleUpdateEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);

        // RabbiMQ - publica sem acessar nenhum serviços externo
        _producer.PublishAsync(request);
    }

    private async Task EmailRabbiMQAppCommand(ExempleUpdateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.Email, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }

    private async Task WhatsAppRabbiMQAppCommand(ExempleUpdateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.WhatsApp, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }
}
