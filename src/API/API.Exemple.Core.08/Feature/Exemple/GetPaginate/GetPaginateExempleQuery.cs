using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Exemple.Core._08.Feature.Exemple.GetPaginate;

public class GetPaginateExempleQuery : QueryRequestPaged<GetPaginateExempleQueryResult, ExempleQueryModel>
{
    [FromQuery]
    public string? FiltroFirstName { get; set; } // Filtro opcional
}