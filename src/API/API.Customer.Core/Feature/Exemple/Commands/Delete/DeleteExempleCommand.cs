using Common.Core._08.Response;
using MediatR;

namespace API.Customer.Core.Feature.Exemple.Commands.Delete;

public record DeleteExempleCommand(Guid Id) : IRequest<ApiResult<DeleteExempleResponse>>;


