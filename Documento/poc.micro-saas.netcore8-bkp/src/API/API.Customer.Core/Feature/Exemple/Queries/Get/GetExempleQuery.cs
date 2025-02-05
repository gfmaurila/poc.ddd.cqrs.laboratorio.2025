using API.Customer.Core.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Customer.Core.Feature.Exemple.Queries.Get;

public record GetExempleQuery : IRequest<ApiResult<List<ExempleQueryModel>>>;


