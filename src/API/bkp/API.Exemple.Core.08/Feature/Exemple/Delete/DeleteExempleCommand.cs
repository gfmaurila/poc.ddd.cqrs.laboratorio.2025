using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Delete;

public record DeleteExempleCommand(Guid Id) : IRequest<ApiResult<DeleteExempleResponse>>;


