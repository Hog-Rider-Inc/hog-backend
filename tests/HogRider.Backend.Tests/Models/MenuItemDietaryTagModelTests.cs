using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class MenuItemDietaryTagModelTests
    {
        [Fact]
        public void Can_Create_MenuItemDietaryTag()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Vegan Bowl",
                Price = 11,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var dietaryTag = new DietaryTag
            {
                Title = "Vegan",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(item, dietaryTag);
            context.SaveChanges();

            var menuItemDietaryTag = new MenuItemDietaryTag
            {
                MenuItemId = item.Id,
                DietaryTagId = dietaryTag.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItemDietaryTags.Add(menuItemDietaryTag);
            context.SaveChanges();

            Assert.Single(context.MenuItemDietaryTags);
        }
    }
}
