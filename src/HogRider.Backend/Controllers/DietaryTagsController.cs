using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HogRider.Backend.Data;
using HogRider.Backend.DTOs;

[ApiController]
[Route("api/dietary-tags")]
public class DietaryTagsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DietaryTagsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tags = await _context.DietaryTags
            .Select(t => new DietaryTagDto
            {
                Id = t.Id,
                Title = t.Title
            })
            .ToListAsync();

        return Ok(tags);
    }
}