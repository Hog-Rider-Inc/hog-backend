using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class MenuItemImageTests
    {
        [Fact]
        public void Can_Create_MenuItemImage()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Wrap",
                Price = 9,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(item);
            context.SaveChanges();

            var image = new MenuItemImage
            {
                MenuItemId = item.Id,
                ImageUrl = "https://test.com/wrap.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItemImages.Add(image);
            context.SaveChanges();

            Assert.Single(context.MenuItemImages);
        }
    }
}
