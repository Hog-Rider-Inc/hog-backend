using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HogRider.Backend.Data;
using HogRider.Backend.DTOs;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Title = c.Title
            })
            .ToListAsync();

        return Ok(categories);
    }
}