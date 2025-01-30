using API.Exemple.Core._08.Feature.Notification;
using API.Exemple.Core._08.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Create.Events.Messaging.Publish;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Create.Events.Messaging;

public class ExempleCreateEventHandler : INotificationHandler<ExempleCreateEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ICreateExemplePublish _producer;


    public ExempleCreateEventHandler(IMediator mediator, IConfiguration configuration, ICreateExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    public async Task Handle(ExempleCreateEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ - Acessando serviços externos.
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);

        // RabbiMQ - publica sem acessar nenhum serviços externo
        _producer.PublishAsync(request);
    }

    private async Task EmailRabbiMQAppCommand(ExempleCreateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.Email, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }

    private async Task WhatsAppRabbiMQAppCommand(ExempleCreateEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.WhatsApp, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }
}
