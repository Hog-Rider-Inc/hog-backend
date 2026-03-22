using HogRider.Backend.Data;
using HogRider.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogRider.Backend.Tests.Models
{
    public class CategoryTests
    {
        [Fact]
        public void Can_Create_Category()
        {
            using var context = TestDbContextFactory.Create();

            var category = new Category { Title = "Fast Food", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };

            context.Categories.Add(category);
            context.SaveChanges();

            Assert.Single(context.Categories);
        }
    }
}
