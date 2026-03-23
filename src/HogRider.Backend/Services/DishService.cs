using HogRider.Backend.Data;
using HogRider.Backend.DTOs;
using HogRider.Backend.Models;
using HogRider.Backend.Services;
using Microsoft.EntityFrameworkCore;

public class DishService : IDishService
{
    private readonly AppDbContext _context;

    public DishService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DishDto>> SearchAsync(string? q)
    {
        var query = _context.MenuItems
            .Include(mi => mi.Restaurant)
            .Include(mi => mi.Images)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(q))
        {
            var lowerQ = q.ToLower();
            query = query.Where(mi => mi.Name.ToLower().Contains(lowerQ));
        }

        var items = await query.ToListAsync();

        return items.Select(mi => new DishDto
        {
            Id = mi.Id,
            Name = mi.Name,
            RestaurantName = mi.Restaurant.Name,
            Price = mi.Price,
            ImageUrl = mi.Images.FirstOrDefault()?.ImageUrl
        }).ToList();
    }
}