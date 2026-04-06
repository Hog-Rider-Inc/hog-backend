using HogRider.Backend.Data;
using HogRider.Backend.DTOs;
using HogRider.Backend.Models;
using HogRider.Backend.Services;
using HogRider.Backend.Tests.Data;
using Xunit;

namespace HogRider.Backend.Tests.Services
{
    public class UserServiceTests
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
                Status = Enums.OrderStatus.Delivered,
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

            var service = new UserService(context);

            var result = await service.GetUserOrdersAsync(client.Id);

            Assert.Equal(2, result.Count);

            Assert.Equal(newerOrder.Id, result[0].Id);
            Assert.Equal(olderOrder.Id, result[1].Id);

            Assert.Equal("confirmed", result[0].Status.ToLower());
            Assert.Equal(20, result[0].TotalPrice);

            Assert.Equal("delivered", result[1].Status.ToLower());
            Assert.Equal(10, result[1].TotalPrice);
        }
        [Fact]
        public async Task GetUserOrdersAsync_Returns_Null_When_User_Not_Found()
        {
            using var context = TestDbContextFactory.Create();

            var service = new UserService(context);

            var result = await service.GetUserOrdersAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserOrdersAsync_Returns_Empty_List_When_No_Orders()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);

            var service = new UserService(context);

            var result = await service.GetUserOrdersAsync(client.Id);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task CreateOrderAsync_Creates_Order_And_Items()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);

            var menuItem = new MenuItem
            {
                Name = "Test",
                Description = "Test",
                Price = 10,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(menuItem);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var request = new CreateOrderRequest
            {
                OrderedMenuItems = new List<OrderedMenuItemDto>
        {
            new OrderedMenuItemDto { Id = menuItem.Id, Quantity = 2 }
        }
            };

            var result = await service.CreateOrderAsync(client.Id, request);

            Assert.True(result);

            var order = context.Orders.First();
            Assert.Equal(20, order.TotalPrice);

            var orderItems = context.OrderMenuItems.ToList();
            Assert.Single(orderItems);
            Assert.Equal(2, orderItems[0].Quantity);
        }

        [Fact]
        public async Task CreateOrderAsync_Throws_When_Items_Empty()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);

            var service = new UserService(context);

            var request = new CreateOrderRequest
            {
                OrderedMenuItems = new List<OrderedMenuItemDto>()
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.CreateOrderAsync(client.Id, request));
        }

        [Fact]
        public async Task CreateOrderAsync_Throws_When_Quantity_Invalid()
        {
            using var context = TestDbContextFactory.Create();

            var client = TestDataFactory.CreateClient(context);
            var restaurant = TestDataFactory.CreateRestaurant(context);
            var menuItem = new MenuItem
            {
                Name = "Test",
                Description = "Test",
                Price = 10,
                RestaurantId = restaurant.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.MenuItems.Add(menuItem);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            var request = new CreateOrderRequest
            {
                OrderedMenuItems = new List<OrderedMenuItemDto>
        {
            new OrderedMenuItemDto { Id = menuItem.Id, Quantity = 0 }
        }
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.CreateOrderAsync(client.Id, request));
        }

        [Fact]
        public async Task CreateOrderAsync_Returns_False_When_User_Not_Found()
        {
            using var context = TestDbContextFactory.Create();

            var service = new UserService(context);

            var request = new CreateOrderRequest
            {
                OrderedMenuItems = new List<OrderedMenuItemDto>
        {
            new OrderedMenuItemDto { Id = 1, Quantity = 1 }
        }
            };

            var result = await service.CreateOrderAsync(999, request);

            Assert.False(result);
        }
    }
}