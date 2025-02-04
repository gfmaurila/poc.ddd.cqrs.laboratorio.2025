using Common.Core._08.Response;
using MediatR;

namespace API.Freelancer.Core.Feature.Exemple.Commands.Delete;

public record DeleteExempleCommand(Guid Id) : IRequest<ApiResult<DeleteExempleResponse>>;


