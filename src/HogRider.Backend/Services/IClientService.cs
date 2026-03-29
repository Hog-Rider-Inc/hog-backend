using HogRider.Backend.DTOs;

namespace HogRider.Backend.Services
{
    public interface IClientService
    {
        Task<List<OrderDto>> GetClientOrdersAsync(int clientId);
    }
}
