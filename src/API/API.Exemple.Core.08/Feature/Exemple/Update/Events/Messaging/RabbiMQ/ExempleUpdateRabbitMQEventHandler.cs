using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using API.Exemple.Core._08.Feature.Notification;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Helper;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Update.Events.Messaging.RabbiMQ;

public class ExempleUpdateRabbitMQEventHandler : INotificationHandler<ExempleUpdateRabbitMQEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;


    public ExempleUpdateRabbitMQEventHandler(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task Handle(ExempleUpdateRabbitMQEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);
    }

    private async Task EmailRabbiMQAppCommand(ExempleUpdateRabbitMQEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.Email, _configuration.GetValue<string>(ExternalApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }

    private async Task WhatsAppRabbiMQAppCommand(ExempleUpdateRabbitMQEvent request)
    {
        await _mediator.Send(new CreateNotificationCommand(ENotificationType.WhatsApp, _configuration.GetValue<string>(ExternalApiConsts.From), EmailHelper.GeneratMessage(), request.Email));
    }
}
