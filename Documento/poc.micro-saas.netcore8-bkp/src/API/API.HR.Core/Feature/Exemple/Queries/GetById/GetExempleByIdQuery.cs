using API.HR.Core.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.HR.Core.Feature.Exemple.Queries.GetById;

public record GetExempleByIdQuery(Guid Id) : IRequest<ApiResult<ExempleQueryModel>>;


