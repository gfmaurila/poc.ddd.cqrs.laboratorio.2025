using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
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


    public ExempleCreateRabbitMQEventHandler(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task Handle(ExempleCreateRabbitMQEvent request, CancellationToken cancellationToken)
    {
        // RabbiMQ
        await EmailRabbiMQAppCommand(request);
        await WhatsAppRabbiMQAppCommand(request);
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
