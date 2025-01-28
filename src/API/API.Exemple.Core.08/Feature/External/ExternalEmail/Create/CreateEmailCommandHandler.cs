using API.Exemple.Core._08.Feature.External.ExternalEmail.Create.Model;
using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;
using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.External.ExternalEmail.Create;



public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, ApiResult<CreateEmailResponse>>
{
    private readonly IExternalEmailService _emailService;
    private readonly ILogger<CreateEmailCommandHandler> _logger;
    public CreateEmailCommandHandler(ILogger<CreateEmailCommandHandler> logger,
                                     IExternalEmailService emailService)
    {
        _emailService = emailService;
        _logger = logger;
    }
    public async Task<ApiResult<CreateEmailResponse>> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
    {
        // Chama o serviço para enviar a mensagem.
        var response = await _emailService.SendMessageAsync(new CreateSendRequest()
        {
            Notification = request.request.Notification,
            Id = request.request.Id,
            To = request.request.To,
            Auth = new ExternalEmailAuth()
            {
                AccountSid = request.request.Auth.AccountSid,
                AuthToken = request.request.Auth.AuthToken,
                From = request.request.Auth.From,
            },
            Body = request.request.Body
        });

        return ApiResult<CreateEmailResponse>.CreateSuccess(new CreateEmailResponse(new CreateEmailResponseModel()
        {
            Code = response.Code,
            DtSend = response.DtSend,
            Request = new EmailRequestModel()
            {
                Id = response.Request.Id,
                Body = response.Request.Body,
                Notification = response.Request.Notification,
                To = response.Request.To,
                Auth = new AuthEmailModel()
                {
                    AccountSid = response.Request.Auth.AccountSid,
                    AuthToken = response.Request.Auth.AuthToken,
                    From = response.Request.Auth.From,
                }
            }
        }), "Cadastrado com sucesso!");
    }
}


