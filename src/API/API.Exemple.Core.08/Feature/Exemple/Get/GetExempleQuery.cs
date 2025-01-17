using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Get;

public class GetExempleQuery : IRequest<ApiResult<List<ExempleQueryModel>>>
{
    public GetExempleQuery()
    {
    }
}
