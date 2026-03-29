using HogRider.Backend.Data;
using HogRider.Backend.DTOs;
using HogRider.Backend.Models;
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

        public async Task<bool> CreateOrderAsync(int userId, CreateOrderRequest request)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == userId);

            if (client == null)
                return false;

            if (client.AddressId == null)
                throw new ArgumentException("Client has no address");

            if (request.OrderedMenuItems == null || !request.OrderedMenuItems.Any())
                throw new ArgumentException("OrderedMenuItems cannot be empty");

            if (request.OrderedMenuItems.Any(i => i.Quantity <= 0))
                throw new ArgumentException("Quantity must be greater than 0");

            var menuItemIds = request.OrderedMenuItems.Select(i => i.Id).ToList();

            var menuItems = await _context.MenuItems
                .Where(mi => menuItemIds.Contains(mi.Id))
                .ToListAsync();

            if (menuItems.Count != menuItemIds.Count)
                throw new ArgumentException("Some menu items do not exist");

            decimal totalPrice = 0;

            foreach (var item in request.OrderedMenuItems)
            {
                var menuItem = menuItems.First(mi => mi.Id == item.Id);
                totalPrice += menuItem.Price * item.Quantity;
            }
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    ClientId = userId,
                    AddressId = client.AddressId.Value,
                    Status = Enums.OrderStatus.pending_acceptance,
                    TotalPrice = totalPrice,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                var orderMenuItems = request.OrderedMenuItems.Select(i => new OrderMenuItem
                {
                    OrderId = order.Id,
                    MenuItemId = i.Id,
                    Quantity = i.Quantity
                });

                _context.OrderMenuItems.AddRange(orderMenuItems);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
