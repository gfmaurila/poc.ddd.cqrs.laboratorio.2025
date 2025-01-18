using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Request;
using Common.Core._08.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Exemple.Core._08.Feature.Exemple.GetPaginate;

//public record GetPaginateExempleQuery(int PageNumber = 1, int PageSize = 10) : IRequest<ApiResult<List<ExempleQueryModel>>>;

public class GetPaginateExempleQuery : QueryRequestPaged<GetPaginateExempleQueryResult, ExempleQueryModel>
{
    [FromQuery]
    public string? FiltroFirstName { get; set; } // Filtro opcional
}



public class GetPaginateExempleQueryResult : QueryResponsePaged<ExempleQueryModel>
{
    public string? Filtro { get; set; } // Filtro aplicado
    public int QuantidadePaginas { get; set; } // Quantidade de páginas

    public GetPaginateExempleQueryResult(int total, List<ExempleQueryModel> items, string? filtro, int quantidadePaginas)
        : base(total, items)
    {
        Filtro = filtro;
        QuantidadePaginas = quantidadePaginas;
    }
}



