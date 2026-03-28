using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class ReviewTests
    {
        [Fact]
        public void Can_Create_Review()
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
                AddressId = address.Id,
                Status = 0,
                TotalPrice = 10,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(order);
            context.SaveChanges();

            var review = new Review
            {
                ClientId = client.Id,
                RestaurantId = restaurant.Id,
                OrderId = order.Id,
                Rating = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Reviews.Add(review);
            context.SaveChanges();

            Assert.Single(context.Reviews);
        }
    }
}