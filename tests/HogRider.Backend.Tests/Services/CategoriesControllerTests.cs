using HogRider.Backend.DTOs;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HogRider.Backend.Tests.Services
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task Get_Returns_All_Categories_As_Dto_List()
        {
            using var context = TestDbContextFactory.Create();

            var category1 = new Category
            {
                Title = "Burgers",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var category2 = new Category
            {
                Title = "Pizza",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Categories.AddRange(category1, category2);
            context.SaveChanges();

            var controller = new CategoriesController(context);

            var actionResult = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var payload = Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(okResult.Value);
            var categories = payload.ToList();

            Assert.Equal(2, categories.Count);
            Assert.Contains(categories, c => c.Title == "Burgers");
            Assert.Contains(categories, c => c.Title == "Pizza");
        }
    }
}
