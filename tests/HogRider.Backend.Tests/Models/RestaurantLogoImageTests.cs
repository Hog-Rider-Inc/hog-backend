using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class RestaurantLogoImageTests
    {
        [Fact]
        public void Can_Create_RestaurantLogoImage()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var logoImage = new RestaurantLogoImage
            {
                RestaurantId = restaurant.Id,
                ImageUrl = "https://test.com/logo.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.RestaurantLogoImages.Add(logoImage);
            context.SaveChanges();

            Assert.Single(context.RestaurantLogoImages);
        }
    }
}
