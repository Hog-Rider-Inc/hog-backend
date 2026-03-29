using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Services;
using HogRider.Backend.Tests.Data;
using Xunit;

namespace HogRider.Backend.Tests.Services
{
    public class ClientServiceTests
    {
        [Fact]
        public async Task GetClientOrdersAsync_Returns_Orders_For_Client_In_Descending_Order()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var olderOrder = new Order
            {
                ClientId = client.Id,
                AddressId = client.AddressId,
                Status = Enums.OrderStatus.pending_acceptance,
                TotalPrice = 10,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow
            };

            var newerOrder = new Order
            {
                ClientId = client.Id,
                AddressId = client.AddressId,
                Status = Enums.OrderStatus.Confirmed,
                TotalPrice = 20,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.AddRange(olderOrder, newerOrder);
            context.SaveChanges();

            var service = new ClientService(context);

            var result = await service.GetClientOrdersAsync(client.Id);

            Assert.Equal(2, result.Count);

            Assert.Equal(newerOrder.Id, result[0].Id);
            Assert.Equal(olderOrder.Id, result[1].Id);

            Assert.Equal("confirmed", result[0].Status.ToLower());
            Assert.Equal(20, result[0].TotalPrice);

            Assert.Equal("pending_acceptance", result[1].Status.ToLower());
            Assert.Equal(10, result[1].TotalPrice);
        }
    }
}