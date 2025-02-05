using API.Customer.Core.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Customer.Core.Feature.Exemple.Queries.GetById;

public record GetExempleByIdQuery(Guid Id) : IRequest<ApiResult<ExempleQueryModel>>;


