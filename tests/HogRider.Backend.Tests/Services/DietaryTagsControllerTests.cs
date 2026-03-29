using HogRider.Backend.DTOs;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HogRider.Backend.Tests.Services
{
    public class DietaryTagsControllerTests
    {
        [Fact]
        public async Task Get_Returns_All_DietaryTags_As_Dto_List()
        {
            using var context = TestDbContextFactory.Create();

            var tag1 = new DietaryTag
            {
                Title = "Vegan",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var tag2 = new DietaryTag
            {
                Title = "Gluten Free",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.DietaryTags.AddRange(tag1, tag2);
            context.SaveChanges();

            var controller = new DietaryTagsController(context);

            var actionResult = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var payload = Assert.IsAssignableFrom<IEnumerable<DietaryTagDto>>(okResult.Value);
            var tags = payload.ToList();

            Assert.Equal(2, tags.Count);
            Assert.Contains(tags, t => t.Title == "Vegan");
            Assert.Contains(tags, t => t.Title == "Gluten Free");
        }
    }
}
