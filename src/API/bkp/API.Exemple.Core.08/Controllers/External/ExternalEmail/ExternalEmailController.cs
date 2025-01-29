namespace API.Exemple.Core._08.Controllers.External.ExternalEmail;
using API.Exemple.Core._08.Controllers;

using API.Exemple.Core._08.Feature.External.ExternalEmail.Create;
using API.Exemple.Core._08.Feature.External.ExternalEmail.Create.Model;
using API.Exemple.Core._08.Feature.External.ExternalEmail.Get;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class ExternalEmailController : BaseController
{
    private readonly ISender _sender;

    private readonly ILogger<ExternalEmailController> _logger;

    public ExternalEmailController(ISender sender, ILogger<ExternalEmailController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Endpoint para listagem paginada de Exemple registrados no sistema.
    /// </summary>
    /// <param name="query">GetPaginateExempleQuery contendo os parâmetros de paginação e filtro.</param>
    /// <param name="cancellationToken">CancellationToken para controle de execução.</param>
    /// <returns>Resultado paginado de Exemple.</returns>
    [HttpGet()]
    //[Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResult<GetPaginateEmailQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetPaginateEmailQuery query, CancellationToken cancellationToken)
    {
        // Envia o comando para o handler
        var result = await _sender.Send(query);

        // Verifica se o resultado é válido
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }


    /// <summary>
    /// Cadastra um novo Exemple no sistema.
    /// </summary>
    /// <param name="command">Dados para criação do Exemple.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost]
    //[Authorize(Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}")]
    [ProducesResponseType(typeof(CreateEmailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateEmailCommand command)
    {
        // Envia o comando para o handler
        var result = await _sender.Send(command);

        // Verifica se a operação foi bem-sucedida
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}

