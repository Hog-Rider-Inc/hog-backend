using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class RestaurantTests
    {
        [Fact]
        public void Should_Create_Restaurant()
        {
            var context = TestDbContextFactory.Create();

            var restaurant = new Restaurant
            {
                Name = "Pizza Place",
                AccountId = 1,
                AddressId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            Assert.Single(context.Restaurants);
        }

        [Fact]
        public void Should_Fail_When_Name_Is_Null()
        {
            var context = TestDbContextFactory.Create();

            var restaurant = new Restaurant
            {
                Name = null!
            };

            context.Restaurants.Add(restaurant);

            Assert.ThrowsAny<Exception>(() => context.SaveChanges());
        }
    }
}