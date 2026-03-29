using HogRider.Backend.DTOs;

namespace HogRider.Backend.Services
{
    public interface IUserService
    {
        Task<List<OrderDto>> GetUserOrdersAsync(int clientId);
        Task<bool> CreateOrderAsync(int userId, CreateOrderRequest request);
    }
}
