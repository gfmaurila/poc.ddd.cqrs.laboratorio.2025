using API.Exemple.Core._08.Feature.Exemple.Delete;
using Carter;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace API.Exemple.Core._08.Endpoints.Exemple;

public class DeleteExempleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/exemple/{id}", HandleDeleteExemple)
            .WithName("DeleteExemple")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
             .WithOpenApi(x => new OpenApiOperation(x)
             {
                 Summary = "Deletar Exemple",
                 Description = "deletar Exemple",
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
    private async Task<IResult> HandleDeleteExemple(Guid id, ISender sender)
    {
        var result = await sender.Send(new DeleteExempleCommand(id));

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
