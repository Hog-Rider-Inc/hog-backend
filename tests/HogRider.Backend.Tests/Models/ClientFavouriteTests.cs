using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class ClientFavouriteTests
    {
        [Fact]
        public void Should_Link_Client_And_MenuItem()
        {
            var context = TestDbContextFactory.Create();

            var client = new Client { FirstName = "John" };
            var restaurant = new Restaurant { Name = "R1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };

            context.AddRange(client, restaurant);
            context.SaveChanges();

            var menuItem = new MenuItem
            {
                Name = "Pizza",
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(menuItem);
            context.SaveChanges();

            var favourite = new ClientFavourite
            {
                ClientId = client.Id,
                MenuItemId = menuItem.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.ClientFavourites.Add(favourite);
            context.SaveChanges();

            Assert.Single(context.ClientFavourites);
        }
    }
}