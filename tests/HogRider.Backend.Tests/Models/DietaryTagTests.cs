using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class DietaryTagTests
    {
        [Fact]
        public void Can_Create_DietaryTag()
        {
            using var context = TestDbContextFactory.Create();

            var tag = new DietaryTag
            {
                Title = "Vegan",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.DietaryTags.Add(tag);
            context.SaveChanges();

            Assert.Single(context.DietaryTags);
        }
    }
}