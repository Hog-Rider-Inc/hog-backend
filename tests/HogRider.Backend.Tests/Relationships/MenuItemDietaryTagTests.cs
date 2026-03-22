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
    public class MenuItemDietaryTagTests
    {
        [Fact]
        public void Can_Link_MenuItem_DietaryTag()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var item = new MenuItem
            {
                Name = "Salad",
                Price = 5,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var tag = new DietaryTag { Title = "Vegan", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };

            context.AddRange(item, tag);
            context.SaveChanges();

            var link = new MenuItemDietaryTag
            {
                MenuItemId = item.Id,
                DietaryTagId = tag.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(link);
            context.SaveChanges();

            Assert.Single(context.MenuItemDietaryTags);
        }
    }
}
