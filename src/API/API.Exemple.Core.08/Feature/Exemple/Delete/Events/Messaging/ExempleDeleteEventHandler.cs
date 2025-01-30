using API.Exemple.Core._08.Feature.Notification;
using API.Exemple.Core._08.Infrastructure.Integration;
using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Delete.Events.Messaging.Publish;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Delete.Events.Messaging;

public class ExempleDeleteEventHandler : INotificationHandler<ExempleDeleteEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IDeleteExemplePublish _producer;


    public ExempleDeleteEventHandler(IMediator mediator, IConfiguration configuration, IDeleteExemplePublish producer)
    {
        _mediator = mediator;
        _configuration = configuration;
        _producer = producer;
    }

    public async Task Handle(ExempleDeleteEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);

        // RabbiMQ - publica sem acessar nenhum serviços externo
        _producer.PublishAsync(request);
    }

    private async Task EmailRabbiMQAppCommand(ExempleDeleteEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.Email, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }

    private async Task WhatsAppRabbiMQAppCommand(ExempleDeleteEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.WhatsApp, _configuration.GetValue<string>(ApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }
}
