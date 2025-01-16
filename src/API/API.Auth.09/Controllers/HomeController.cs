using Microsoft.AspNetCore.Mvc;

namespace API.Auth.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok("API is running");
    }
}
