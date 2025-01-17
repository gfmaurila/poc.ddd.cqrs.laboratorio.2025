using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Get;
using Carter;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace API.Exemple.Core._08.Endpoints.Exemple;

public class GetAllExempleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/exemple", HandleGetAllExemple)
            .WithName("GetAllExemple")
            .Produces<ApiResponse<List<ExempleQueryModel>>>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Buscar todos os Exemple",
                Description = "Retorna uma lista com todos os Exemple registrados no sistema.",
                Tags = new List<OpenApiTag>
                {
                    new OpenApiTag
                    {
                        Name = "Exemple"
                    }
                }
            })
            .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.EMPLOYEE_AUTH}, {RoleConstants.ADMIN_AUTH}" })
            ;
    }

    private async Task<IResult> HandleGetAllExemple(ISender sender)
    {
        var result = await sender.Send(new GetExempleQuery());

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
