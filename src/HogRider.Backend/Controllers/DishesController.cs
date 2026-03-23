using Microsoft.AspNetCore.Mvc;
using HogRider.Backend.Services;

[ApiController]
[Route("api/dishes")]
public class DishesController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string? q)
    {
        var result = await _dishService.SearchAsync(q);
        return Ok(result);
    }
}