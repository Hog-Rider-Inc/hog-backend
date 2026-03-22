using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogRider.Backend.Tests.Models
{
    public class OrderTests
    {
        [Fact]
        public void Can_Create_Order()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);
            var address = TestDataFactory.CreateAddress();

            context.Add(address);
            context.SaveChanges();

            var order = new Order
            {
                ClientId = client.Id,
                RestaurantId = restaurant.Id,
                AddressId = address.Id,
                Status = 0,
                TotalPrice = 20,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Orders.Add(order);
            context.SaveChanges();

            Assert.Single(context.Orders);
        }
    }
}
