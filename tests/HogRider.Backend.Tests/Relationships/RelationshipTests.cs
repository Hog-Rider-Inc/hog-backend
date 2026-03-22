using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Relationships
{
    public class RelationshipTests
    {
        [Fact]
        public void MenuItem_Should_Load_Restaurant()
        {
            var context = TestDbContextFactory.Create();

            var restaurant = new Restaurant
            {
                Name = "R1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            var item = new MenuItem
            {
                Name = "Pasta",
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(item);
            context.SaveChanges();

            var result = context.MenuItems
                .Include(x => x.Restaurant)
                .First();

            Assert.NotNull(result.Restaurant);
        }
    }
}