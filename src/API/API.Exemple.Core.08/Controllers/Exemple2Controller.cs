namespace API.Exemple.Core._08.Controllers;

using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Create;
using API.Exemple.Core._08.Feature.Exemple.Delete;
using API.Exemple.Core._08.Feature.Exemple.Get;
using API.Exemple.Core._08.Feature.Exemple.GetById;
using API.Exemple.Core._08.Feature.Exemple.GetPaginate;
using API.Exemple.Core._08.Feature.Exemple.Update;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class Exemple2Controller : BaseController
{
    private readonly ISender _sender;

    private readonly ILogger<Exemple2Controller> _logger;

    public Exemple2Controller(ISender sender, ILogger<Exemple2Controller> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Retorna uma lista com todos os Exemple registrados no sistema.
    /// </summary>
    /// <returns>Lista de Exemple.</returns>
    [HttpGet]
    //[Authorize(Roles = $"{RoleConstants.EMPLOYEE_AUTH}, {RoleConstants.ADMIN_AUTH}")]
    [ProducesResponseType(typeof(ApiResponse<List<ExempleQueryModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllExemple()
    {
        // Envia o comando para buscar todos os exemplos
        var result = await _sender.Send(new GetExempleQuery());

        // Verifica o resultado da operação
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    /// <summary>
    /// Endpoint para listagem paginada de Exemple registrados no sistema.
    /// </summary>
    /// <param name="query">GetPaginateExempleQuery contendo os parâmetros de paginação e filtro.</param>
    /// <param name="cancellationToken">CancellationToken para controle de execução.</param>
    /// <returns>Resultado paginado de Exemple.</returns>
    [HttpGet("exemple")]
    [ProducesResponseType(typeof(ApiResult<GetPaginateExempleQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllExemple([FromQuery] GetPaginateExempleQuery query, CancellationToken cancellationToken)
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
    /// Retorna um Exemple específico pelo seu ID.
    /// </summary>
    /// <param name="id">Identificador do Exemple.</param>
    /// <returns>O Exemple correspondente ao ID.</returns>
    [HttpGet("{id}")]
    //[Authorize(Roles = $"{RoleConstants.EMPLOYEE_AUTH}, {RoleConstants.ADMIN_AUTH}")]
    [ProducesResponseType(typeof(ApiResponse<ExempleQueryModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetExempleById(Guid id)
    {
        // Cria o comando para buscar o Exemple pelo ID
        var query = new GetExempleByIdQuery(id);

        // Envia o comando para o mediador e obtém o resultado
        var result = await _sender.Send(query);

        // Retorna um erro caso a operação não tenha sido bem-sucedida
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
    [ProducesResponseType(typeof(CreateExempleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateExemple([FromBody] CreateExempleCommand command)
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

    /// <summary>
    /// Atualiza os dados de um Exemple existente.
    /// </summary>
    /// <param name="command">Dados para atualização do Exemple.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPut]
    //[Authorize(Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateExemple([FromBody] UpdateExempleCommand command)
    {
        // Envia o comando de atualização para o mediador
        var result = await _sender.Send(command);

        // Verifica se a operação foi bem-sucedida
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    /// <summary>
    /// Deleta um Exemple pelo ID.
    /// </summary>
    /// <param name="id">Identificador do Exemple a ser deletado.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpDelete("{id}")]
    //[Authorize(Roles = $"{RoleConstants.EMPLOYEE_AUTH}, {RoleConstants.ADMIN_AUTH}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteExemple(Guid id)
    {
        // Envia o comando de deleção para o handler
        var result = await _sender.Send(new DeleteExempleCommand(id));

        // Retorna erro de validação ou estado incorreto
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}

