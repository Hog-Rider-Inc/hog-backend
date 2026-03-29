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
    public async Task<IActionResult> Search(
     [FromQuery] string? q,
     [FromQuery] string? category,
     [FromQuery] string? dietary)
    {
        var result = await _dishService.SearchAsync(q, category, dietary);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDish(int id)
    {
        var dish = await _dishService.GetDishByIdAsync(id);

        if (dish == null)
            return NotFound();

        return Ok(dish);
    }
}