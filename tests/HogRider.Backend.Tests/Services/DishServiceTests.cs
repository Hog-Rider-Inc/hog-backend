using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Services;
using HogRider.Backend.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HogRider.Backend.Tests.Services
{
    public class DishServiceTests
    {
        [Fact]
        public async Task GetDishByIdAsync_Returns_Dish_With_All_Data()
        {
            using var context = TestDbContextFactory.Create();

            var restaurant = TestDataFactory.CreateRestaurant(context);

            var category = new Category
            {
                Title = $"Cat_{Guid.NewGuid()}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var dietary = new DietaryTag
            {
                Title = $"Diet_{Guid.NewGuid()}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(category, dietary);
            context.SaveChanges();

            var menuItem = new MenuItem
            {
                Name = "Burger",
                Description = "Test desc",
                Price = 10,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(menuItem);
            context.SaveChanges();

            var image = new MenuItemImage
            {
                MenuItemId = menuItem.Id,
                ImageUrl = "test.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var mic = new MenuItemCategory
            {
                MenuItemId = menuItem.Id,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var midt = new MenuItemDietaryTag
            {
                MenuItemId = menuItem.Id,
                DietaryTagId = dietary.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(image, mic, midt);
            context.SaveChanges();

            var service = new DishService(context);

            var result = await service.GetDishByIdAsync(menuItem.Id);

            Assert.NotNull(result);
            Assert.Equal("Burger", result!.Name);
            Assert.Equal("Test desc", result.Description);
            Assert.Equal(10, result.Price);
            Assert.Equal(restaurant.Name, result.RestaurantName);

            Assert.Single(result.Images);
            Assert.Equal("test.jpg", result.Images.First());

            Assert.Single(result.Categories);
            Assert.Equal(category.Title, result.Categories.First());

            Assert.Single(result.DietaryTags);
            Assert.Equal(dietary.Title, result.DietaryTags.First());
        }
    }
}