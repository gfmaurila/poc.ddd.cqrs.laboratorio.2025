using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.GetById;
using Carter;
using Common.Core._08.Response;
using MediatR;
using Microsoft.OpenApi.Models;

namespace API.Exemple.Core._08.Endpoints.Exemple;

public class GetExempleByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/exemple/{id}", HandleGetExempleById)
            .WithName("GetExempleById")
            .Produces<ApiResponse<ExempleQueryModel>>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Buscar Exemple por ID",
                Description = "Retorna um Exemple específico pelo seu ID",
                Tags = new List<OpenApiTag>
                {
                    new OpenApiTag
                    {
                        Name = "Exemple"
                    }
                }
            })
            //.RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.EMPLOYEE_AUTH}, {RoleConstants.EMPLOYEE_AUTH}" })
            ;
    }
    private async Task<IResult> HandleGetExempleById(Guid id, ISender sender)
    {
        var query = new GetExempleByIdQuery(id);
        var result = await sender.Send(query);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
