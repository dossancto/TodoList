using Microsoft.AspNetCore.Mvc;

namespace TodoList.Src.Controllers;

[ApiController]
[Route("hellos")]
public class HellosController : ControllerBase
{
    [HttpGet("salve")]
    public IActionResult Get(string name)
    {
        return Ok($"Hello {name}");
    }

    [HttpGet("product/{productId}")]
    public IActionResult GetProduct(string productId)
    {
        return Ok(productId);
    }
}
