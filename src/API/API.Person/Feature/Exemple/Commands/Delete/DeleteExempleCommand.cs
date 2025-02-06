using Common.Core._08.Response;
using MediatR;

namespace API.Person.Feature.Exemple.Commands.Delete;

public record DeleteExempleCommand(Guid Id) : IRequest<ApiResult<DeleteExempleResponse>>;


