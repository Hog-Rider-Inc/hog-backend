using HogRider.Backend.Data;
using HogRider.Backend.Enums;
using HogRider.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Relationships
{
    public class RelationshipTests
    {
        [Fact]
        public void MenuItem_Should_Load_Restaurant()
        {
            using var context = TestDbContextFactory.Create();

            // 🔥 1. Account
            var account = new Account
            {
                AccountType = AccountType.Restaurant,
                Username = "rest",
                Email = "rest@test.com",
                PasswordHash = "123",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // 🔥 2. Address
            var address = new Address
            {
                Country = "LT",
                City = "Vilnius",
                Street = "Test",
                PostalCode = "12345",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(account, address);
            context.SaveChanges();

            // 🔥 3. Restaurant
            var restaurant = new Restaurant
            {
                Name = "Test Restaurant",
                AccountId = account.Id,
                AddressId = address.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            // 🔥 4. MenuItem
            var item = new MenuItem
            {
                Name = "Pizza",
                Price = 10,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(item);
            context.SaveChanges();

            // 🔥 5. Load su Include
            var loaded = context.MenuItems
                .Include(m => m.Restaurant)
                .First();

            Assert.NotNull(loaded.Restaurant);
            Assert.Equal("Test Restaurant", loaded.Restaurant!.Name);
        }
    }
}