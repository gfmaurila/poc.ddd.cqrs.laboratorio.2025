using API.Freelancer.Core.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Freelancer.Core.Feature.Exemple.Queries.Get;

public record GetExempleQuery : IRequest<ApiResult<List<ExempleQueryModel>>>;


