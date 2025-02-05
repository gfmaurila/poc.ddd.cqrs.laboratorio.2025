using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;

namespace API.Exemple.Core._08.Feature.Exemple.GetPaginate;

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