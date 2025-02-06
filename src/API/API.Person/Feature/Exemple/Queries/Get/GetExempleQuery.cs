using API.Person.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Person.Feature.Exemple.Queries.Get;

public record GetExempleQuery : IRequest<ApiResult<List<ExempleQueryModel>>>;


