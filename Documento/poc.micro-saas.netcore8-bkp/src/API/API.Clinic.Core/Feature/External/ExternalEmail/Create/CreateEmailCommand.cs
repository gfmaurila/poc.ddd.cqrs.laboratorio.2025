using API.Clinic.Core.Feature.External.ExternalEmail.Create.Model;
using Common.Core._08.Response;
using MediatR;

namespace API.Clinic.Core.Feature.External.ExternalEmail.Create;

public record CreateEmailCommand(CreateEmailModel request) : IRequest<ApiResult<CreateEmailResponse>>;

