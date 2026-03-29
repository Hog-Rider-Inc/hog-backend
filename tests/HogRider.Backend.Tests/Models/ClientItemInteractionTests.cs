using HogRider.Backend.Enums;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class ClientItemInteractionTests
    {
        [Fact]
        public void Can_Create_ClientItemInteraction()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Pasta",
                Price = 12,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(item);
            context.SaveChanges();

            var interaction = new ClientItemInteraction
            {
                ClientId = client.Id,
                MenuItemId = item.Id,
                Interaction = InteractionType.like,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.ClientItemInteractions.Add(interaction);
            context.SaveChanges();

            Assert.Single(context.ClientItemInteractions);
        }
    }
}
