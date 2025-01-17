using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Exemple.Core._08.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ExempleController(ISender sender, ILogger<ExempleController> logger) : BaseController(logger)
{
    private readonly ISender _sender = sender;

    [HttpGet("GetOK")]
    public async Task<IActionResult> GetOK()
    {
        return Ok("Teste");
    }

    [HttpGet("BadRequest")]
    public async Task<IActionResult> GetBadRequest()
    {
        return BadRequest("Teste");
    }

    [HttpGet("NoContent")]
    public async Task<IActionResult> GetNoContent()
    {
        return NoContent();
    }

    //[HttpGet("HandleError")]
    //public async Task<IActionResult> GetHandleError()
    //{
    //    if (id != command.BasketId)
    //        return BadRequest("Basket ID in URL does not match the command.");

    //    var result = await _sender.Send(command);
    //    if (result.IsSuccess)
    //        return NoContent();
    //    else
    //        return HandleError(result.Error);
    //}

    //[HttpGet("CreatedAtAction")]
    //public async Task<IActionResult> GetCreatedAtAction()
    //{
    //    var result = await _sender.Send(command);
    //    if (result.IsSuccess)
    //        return CreatedAtAction(nameof(GetBasket), new { id = result.Value }, result.Value);
    //    return HandleError(result.Error);
    //}

    [HttpGet("/test")]
    public string Test()
    {
        return "hello";
    }
}
