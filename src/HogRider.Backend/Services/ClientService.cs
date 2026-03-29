using HogRider.Backend.Data;
using HogRider.Backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HogRider.Backend.Services
{
    public class ClientService: IClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>> GetClientOrdersAsync(int clientId)
        {
            return await _context.Orders
                .Where(o => o.ClientId == clientId)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    Status = o.Status.ToString(),
                    TotalPrice = o.TotalPrice,
                    CreatedAt = o.CreatedAt
                })
                .ToListAsync();
        }
    }
}
