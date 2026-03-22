using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class MenuItemTests
    {
        [Fact]
        public void Should_Create_MenuItem_With_Valid_Data()
        {
            // Arrange
            var context = TestDbContextFactory.Create();

            var restaurant = new Restaurant
            {
                Name = "Test Restaurant",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            var menuItem = new MenuItem
            {
                Name = "Burger",
                Price = 9.99m,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act
            context.MenuItems.Add(menuItem);
            context.SaveChanges();

            // Assert
            var saved = context.MenuItems.First();

            Assert.Equal("Burger", saved.Name);
            Assert.Equal(restaurant.Id, saved.RestaurantId);
        }

        [Fact]
        public void Should_Fail_When_Name_Is_Empty()
        {
            var context = TestDbContextFactory.Create();

            var menuItem = new MenuItem
            {
                Name = "",
                Price = 5
            };

            context.MenuItems.Add(menuItem);

            Assert.ThrowsAny<Exception>(() => context.SaveChanges());
        }
    }
}