using HogRider.Backend.Data;
using HogRider.Backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HogRider.Backend.Services
{
    public class UserService: IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>?> GetUserOrdersAsync(int userId)
        {
            var clientExists = await _context.Clients
                .AnyAsync(c => c.Id == userId);

            if (!clientExists)
                return null;

            return await _context.Orders
                .Where(o => o.ClientId == userId)
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
