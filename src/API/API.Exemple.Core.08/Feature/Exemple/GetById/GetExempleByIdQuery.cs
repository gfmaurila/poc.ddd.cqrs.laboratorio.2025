using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.GetById;

public record GetExempleByIdQuery(Guid Id) : IRequest<ApiResult<ExempleQueryModel>>;


