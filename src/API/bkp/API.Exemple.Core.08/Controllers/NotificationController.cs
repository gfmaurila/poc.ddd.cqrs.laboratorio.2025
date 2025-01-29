namespace API.Exemple.Core._08.Controllers;

using API.Exemple.Core._08.Feature.Notification;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class NotificationController : BaseController
{
    private readonly ISender _sender;

    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ISender sender, ILogger<NotificationController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Cadastra um novo Exemple no sistema.
    /// </summary>
    /// <param name="command">Dados para criação do Exemple.</param>
    /// <returns>Resultado da operação.</returns>
    [HttpPost]
    //[Authorize(Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}")]
    [ProducesResponseType(typeof(CreateNotificationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateExemple([FromBody] CreateNotificationCommand command)
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

