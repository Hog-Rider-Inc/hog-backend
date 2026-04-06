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

        [Fact]
        public async Task SearchAsync_With_Query_Pizza_Returns_Only_Matching_Names()
        {
            using var context = TestDbContextFactory.Create();
            SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync("pizza", null, null);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
                Assert.Contains("pizza", dish.Name, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public async Task SearchAsync_With_Null_Query_Returns_All_Dishes()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync(null, null, null);

            Assert.Equal(seed.AllDishIds.Count, result.Count);
        }

        [Fact]
        public async Task SearchAsync_With_Non_Existing_Query_Returns_Empty()
        {
            using var context = TestDbContextFactory.Create();
            SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync("xyz123", null, null);

            Assert.Empty(result);
        }

        [Fact]
        public async Task SearchAsync_With_Category_Sriubos_Returns_Only_Sriubos_Dishes()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync(null, seed.SriubosTitle, null);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
                Assert.True(HasCategory(context, dish.Id, seed.SriubosTitle)));
        }

        [Fact]
        public async Task SearchAsync_With_Dietary_Vegan_Returns_Only_Vegan_Dishes()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync(null, null, seed.VeganTitle);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
                Assert.True(HasDietary(context, dish.Id, seed.VeganTitle)));
        }

        [Fact]
        public async Task SearchAsync_With_Query_And_Category_Returns_Intersection()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync("pizza", seed.SriubosTitle, null);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
            {
                Assert.Contains("pizza", dish.Name, StringComparison.OrdinalIgnoreCase);
                Assert.True(HasCategory(context, dish.Id, seed.SriubosTitle));
            });
        }

        [Fact]
        public async Task SearchAsync_With_Query_And_Dietary_Returns_Intersection()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync("pizza", null, seed.VeganTitle);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
            {
                Assert.Contains("pizza", dish.Name, StringComparison.OrdinalIgnoreCase);
                Assert.True(HasDietary(context, dish.Id, seed.VeganTitle));
            });
        }

        [Fact]
        public async Task SearchAsync_With_All_Filters_Returns_Only_Full_Matches()
        {
            using var context = TestDbContextFactory.Create();
            var seed = SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync("pizza", seed.SriubosTitle, seed.VeganTitle);

            Assert.NotEmpty(result);
            Assert.All(result, dish =>
            {
                Assert.Contains("pizza", dish.Name, StringComparison.OrdinalIgnoreCase);
                Assert.True(HasCategory(context, dish.Id, seed.SriubosTitle));
                Assert.True(HasDietary(context, dish.Id, seed.VeganTitle));
            });
        }

        [Fact]
        public async Task SearchAsync_With_Invalid_Category_Returns_Empty()
        {
            using var context = TestDbContextFactory.Create();
            SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync(null, "NeteisingaKategorija", null);

            Assert.Empty(result);
        }

        [Fact]
        public async Task SearchAsync_With_Invalid_Dietary_Returns_Empty()
        {
            using var context = TestDbContextFactory.Create();
            SeedSearchData(context);
            var service = new DishService(context);

            var result = await service.SearchAsync(null, null, "NeteisingasDietary");

            Assert.Empty(result);
        }

        private static SearchSeedData SeedSearchData(AppDbContext context)
        {
            var now = DateTime.UtcNow;
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var sriubos = new Category { Title = "Sriubos", CreatedAt = now, UpdatedAt = now };
            var picos = new Category { Title = "Picos", CreatedAt = now, UpdatedAt = now };
            var salotos = new Category { Title = "Salotos", CreatedAt = now, UpdatedAt = now };

            var vegan = new DietaryTag { Title = "Vegan", CreatedAt = now, UpdatedAt = now };
            var keto = new DietaryTag { Title = "Keto", CreatedAt = now, UpdatedAt = now };

            context.AddRange(sriubos, picos, salotos, vegan, keto);
            context.SaveChanges();

            var pizzaSriuba = CreateDish(context, restaurant.Id, "Tomato pizza soup", sriubos.Id, vegan.Id, now);
            var chickenPizza = CreateDish(context, restaurant.Id, "Chicken pizza", picos.Id, keto.Id, now);
            var pumpkinSoup = CreateDish(context, restaurant.Id, "Pumpkin soup", sriubos.Id, keto.Id, now);
            var veganSalad = CreateDish(context, restaurant.Id, "Vegan salad", salotos.Id, vegan.Id, now);

            return new SearchSeedData
            {
                SriubosTitle = sriubos.Title,
                VeganTitle = vegan.Title,
                AllDishIds = new List<int>
                {
                    pizzaSriuba.Id,
                    chickenPizza.Id,
                    pumpkinSoup.Id,
                    veganSalad.Id
                }
            };
        }

        private static MenuItem CreateDish(
            AppDbContext context,
            int restaurantId,
            string name,
            int categoryId,
            int dietaryTagId,
            DateTime now)
        {
            var dish = new MenuItem
            {
                Name = name,
                Description = $"Description for {name}",
                Price = 9.99m,
                RestaurantId = restaurantId,
                CreatedAt = now,
                UpdatedAt = now
            };

            context.MenuItems.Add(dish);
            context.SaveChanges();

            context.MenuItemCategories.Add(new MenuItemCategory
            {
                MenuItemId = dish.Id,
                CategoryId = categoryId,
                CreatedAt = now,
                UpdatedAt = now
            });

            context.MenuItemDietaryTags.Add(new MenuItemDietaryTag
            {
                MenuItemId = dish.Id,
                DietaryTagId = dietaryTagId,
                CreatedAt = now,
                UpdatedAt = now
            });

            context.SaveChanges();
            return dish;
        }

        private static bool HasCategory(AppDbContext context, int dishId, string categoryTitle)
        {
            return context.MenuItemCategories
                .Include(x => x.Category)
                .Any(x => x.MenuItemId == dishId && x.Category!.Title == categoryTitle);
        }

        private static bool HasDietary(AppDbContext context, int dishId, string dietaryTitle)
        {
            return context.MenuItemDietaryTags
                .Include(x => x.DietaryTag)
                .Any(x => x.MenuItemId == dishId && x.DietaryTag!.Title == dietaryTitle);
        }

        private class SearchSeedData
        {
            public string SriubosTitle { get; set; } = "";
            public string VeganTitle { get; set; } = "";
            public List<int> AllDishIds { get; set; } = new();
        }
    }
}