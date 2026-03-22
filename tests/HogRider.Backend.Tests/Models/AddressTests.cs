using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class AddressTests
    {
        [Fact]
        public void Can_Create_Address()
        {
            using var context = TestDbContextFactory.Create();

            var address = new Address
            {
                Country = "Lithuania",
                City = "Vilnius",
                Street = "Gedimino pr.",
                PostalCode = "12345",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            Assert.Single(context.Addresses);
        }
    }
}