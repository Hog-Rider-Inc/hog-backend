using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogRider.Backend.Tests.Relationships
{
    public class MenuItemCategoryTests
    {
        [Fact]
        public void Can_Link_MenuItem_Category()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Burger",
                Price = 8,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var category = new Category { Title = "Fast Food", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };

            context.AddRange(item, category);
            context.SaveChanges();

            var link = new MenuItemCategory
            {
                MenuItemId = item.Id,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(link);
            context.SaveChanges();

            Assert.Single(context.MenuItemCategories);
        }
    }
}
