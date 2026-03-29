using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class ClientRecommendationTests
    {
        [Fact]
        public void Can_Create_ClientRecommendation()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Soup",
                Price = 7,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(item);
            context.SaveChanges();

            var recommendation = new ClientRecommendation
            {
                ClientId = client.Id,
                MenuItemId = item.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.ClientRecommendations.Add(recommendation);
            context.SaveChanges();

            Assert.Single(context.ClientRecommendations);
        }
    }
}
