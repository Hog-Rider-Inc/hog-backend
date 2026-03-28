using HogRider.Backend.DTOs;

namespace HogRider.Backend.Services
{
    public interface IDishService
    {
        Task<List<DishDto>> SearchAsync(string? q, string? category, string? dietary);
        Task <DishDetailsDto?> GetDishByIdAsync(int id);
    }
}
