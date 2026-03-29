using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class OrderMenuItemTests
    {
        [Fact]
        public void Can_Create_OrderMenuItem()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var address = TestDataFactory.CreateAddress();
            var restaurant = TestDataFactory.CreateRestaurant(context);

            context.Add(address);
            context.SaveChanges();

            var order = new Order
            {
                ClientId = client.Id,
                AddressId = address.Id,
                Status = 0,
                TotalPrice = 18,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var item = new MenuItem
            {
                Name = "Salad",
                Price = 6,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(order, item);
            context.SaveChanges();

            var orderItem = new OrderMenuItem
            {
                OrderId = order.Id,
                MenuItemId = item.Id,
                Quantity = 3,
                PriceAtOrder = 6,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.OrderMenuItems.Add(orderItem);
            context.SaveChanges();

            Assert.Single(context.OrderMenuItems);
        }
    }
}
