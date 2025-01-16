using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ModeloController(ISender sender, ILogger<ModeloController> logger) : BaseController(logger)
{
    private readonly ISender _sender = sender;

}
