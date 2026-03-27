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

    public async Task<List<DishDto>> SearchAsync(string? q, string? category, string? dietary)
    {
        var query = _context.MenuItems
            .Include(mi => mi.Restaurant)
            .Include(mi => mi.Images)
            .Include(mi => mi.MenuItemCategories)
                .ThenInclude(mic => mic.Category)
            .Include(mi => mi.MenuItemDietaryTags)
                .ThenInclude(midt => midt.DietaryTag)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(q))
        {
            query = query.Where(mi =>
                EF.Functions.Like(mi.Name, $"%{q}%"));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(mi =>
                mi.MenuItemCategories.Any(mic =>
                    mic.Category!.Title == category));
        }

        if (!string.IsNullOrWhiteSpace(dietary))
        {
            query = query.Where(mi =>
                mi.MenuItemDietaryTags.Any(midt =>
                    midt.DietaryTag!.Title == dietary));
        }

        return await query.Select(mi => new DishDto
        {
            Id = mi.Id,
            Name = mi.Name,
            RestaurantName = mi.Restaurant != null ? mi.Restaurant.Name : "",
            Price = mi.Price,
            ImageUrl = mi.Images.Select(i => i.ImageUrl).FirstOrDefault()
        }).ToListAsync();
    }
}