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
        public void Can_Add_Favourite()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Burger",
                Price = 5,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(item);
            context.SaveChanges();

            var fav = new ClientFavourite
            {
                ClientId = client.Id,
                MenuItemId = item.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(fav);
            context.SaveChanges();

            Assert.Single(context.ClientFavourites);
        }
    }
}