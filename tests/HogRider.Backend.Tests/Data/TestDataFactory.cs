using HogRider.Backend.Data;
using HogRider.Backend.Models;

namespace HogRider.Backend.Tests.Data
{
    public static class TestDataFactory
    {
        public static Account CreateAccount() => new()
        {
            Username = $"user_{Guid.NewGuid()}",
            Email = $"email_{Guid.NewGuid()}@test.com",
            PasswordHash = "123",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        public static Address CreateAddress() => new()
        {
            Country = "LT",
            City = "Vilnius",
            Street = "Test",
            PostalCode = "12345",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        public static Restaurant CreateRestaurant(AppDbContext context)
        {
            var account = CreateAccount();
            var address = CreateAddress();

            context.AddRange(account, address);
            context.SaveChanges();

            var restaurant = new Restaurant
            {
                Name = "Test Restaurant",
                AccountId = account.Id,
                AddressId = address.Id,
                PhoneNumber = "123456",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(restaurant);
            context.SaveChanges();

            return restaurant;
        }

        public static Client CreateClient(AppDbContext context)
        {
            var account = CreateAccount();
            var address = CreateAddress();

            context.AddRange(account, address);
            context.SaveChanges();

            var client = new Client
            {
                AccountId = account.Id,
                AddressId = address.Id,
                FirstName = "Test",
                LastName = "User",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Add(client);
            context.SaveChanges();

            return client;
        }
    }
}