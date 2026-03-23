using HogRider.Backend.DTOs;

namespace HogRider.Backend.Services
{
    public interface IDishService
    {
        Task<List<DishDto>> SearchAsync(string? q);
    }
}
