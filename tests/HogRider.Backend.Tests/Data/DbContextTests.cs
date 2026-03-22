using Xunit;
using HogRider.Backend.Data;
using System.Linq;

namespace HogRider.Backend.Tests.Data
{
    public class DbContextTests
    {
        [Fact]
        public void Can_Connect_To_InMemory_Database()
        {
            using var context = TestDbContextFactory.Create();

            var canConnect = context.Database.CanConnect();

            Assert.True(canConnect);
        }

        [Fact]
        public void Tables_Are_Created()
        {
            using var context = TestDbContextFactory.Create();

            var tables = context.Model.GetEntityTypes().Count();

            Assert.True(tables > 0);
        }
    }
}