using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Customer.Controllers;

/// <summary>
/// Controller responsible for managing Exemple entities, including creation, retrieval, updating, and deletion.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class ExempleController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<ExempleController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleController"/> class.
    /// </summary>
    /// <param name="sender">Mediator instance for handling requests.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public ExempleController(ISender sender, ILogger<ExempleController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves a list of all Exemple entities.
    /// </summary>
    /// <returns>A list of all registered Exemple entities.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all Exemple records.");
        return Ok();
    }
}
