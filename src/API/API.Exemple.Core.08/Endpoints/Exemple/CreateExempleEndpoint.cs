using API.Exemple.Core._08.Feature.Exemple.Create;
using Carter;
using Common.Core._08.Response;
using MediatR;
using Microsoft.OpenApi.Models;

namespace API.Exemple.Core._08.Endpoints.Exemple;

public class CreateExempleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/exemple", HandleCreateExemple)
            .WithName("CreateExemple")
            .Produces<CreateExempleResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x =>
            {
                x.OperationId = "CreateExemple";
                x.Summary = "Inserir Exemple";
                x.Description = "Cadastra um novo Exemple no sistema.";
                x.Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Exemple" } };
                return x;
            })
            //.RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}" })
            ;
    }
    private async Task<IResult> HandleCreateExemple(CreateExempleCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        if (!result.Success)
            return Results.BadRequest(result);
        return Results.Ok(result);
    }
}
