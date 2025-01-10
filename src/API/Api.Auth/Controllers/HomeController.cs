using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    public string Get()
    {
        return "hello - Api Auth";
    }
}
