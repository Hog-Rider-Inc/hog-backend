using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class MenuItemCategoryModelTests
    {
        [Fact]
        public void Can_Create_MenuItemCategory()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Steak",
                Price = 20,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var category = new Category
            {
                Title = "Dinner",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(item, category);
            context.SaveChanges();

            var menuItemCategory = new MenuItemCategory
            {
                MenuItemId = item.Id,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItemCategories.Add(menuItemCategory);
            context.SaveChanges();

            Assert.Single(context.MenuItemCategories);
        }
    }
}
