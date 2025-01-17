using API.Exemple.Core._08.Feature.Exemple.Update;
using Carter;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace API.Exemple.Core._08.Endpoints.Exemple;


public class UpdateExempleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/exemple", HandleUpdateExemple)
            .WithName("UpdateExemple")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Atualizar dados do Exemple",
                Description = "Atualiza os dados de um Exemple existente, utilizando o ID fornecido no corpo da requisição para identificação. Os dados atualizáveis incluem nome, email, senha, entre outros campos pertinentes.",
                Tags = new List<OpenApiTag>
                {
                    new OpenApiTag
                    {
                        Name = "Exemple"
                    }
                }
            })
            .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}" })
            ;
    }

    private async Task<IResult> HandleUpdateExemple(UpdateExempleCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}