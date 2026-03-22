using HogRider.Backend.Data;
using HogRider.Backend.Enums;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class AccountTests
    {
        [Fact]
        public void Can_Create_Account()
        {
            using var context = TestDbContextFactory.Create();

            var account = new Account
            {
                AccountType = AccountType.Client,
                Username = "testuser",
                Email = "test@test.com",
                PasswordHash = "hashed",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Accounts.Add(account);
            context.SaveChanges();

            Assert.Single(context.Accounts);
        }
    }
}