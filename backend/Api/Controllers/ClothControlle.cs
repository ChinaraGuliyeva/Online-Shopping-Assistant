using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClothController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Test"); 
}
