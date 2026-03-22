using HogRider.Backend.Data;
using HogRider.Backend.Models;
using HogRider.Backend.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace HogRider.Backend.Tests.Models
{
    public class ReviewTests
    {
    //    [Fact]
    //    public void Should_Create_Review_With_Relations()
    //    {
    //        var context = TestDbContextFactory.Create();

    //        var restaurant = new Restaurant { Name = "R1", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    //        var client = new Client { FirstName = "John" };
    //        var order = new Order();

    //        context.AddRange(restaurant, client, order);
    //        context.SaveChanges();

    //        var review = new Review
    //        {
    //            ClientId = client.Id,
    //            RestaurantId = restaurant.Id,
    //            OrderId = order.Id,
    //            Rating = 5,
    //            CreatedAt = DateTime.UtcNow,
    //            UpdatedAt = DateTime.UtcNow
    //        };

    //        context.Reviews.Add(review);
    //        context.SaveChanges();

    //        Assert.Single(context.Reviews);
    //    }

    //    [Fact]
    //    public void Should_Save_Invalid_Rating_If_No_Validation()
    //    {
    //        var context = TestDbContextFactory.Create();

    //        var review = new Review
    //        {
    //            Rating = 999 // ⚠️ šitas praeis jei nėra [Range]
    //        };

    //        context.Reviews.Add(review);
    //        context.SaveChanges();

    //        Assert.Equal(999, context.Reviews.First().Rating);
    //    }
    }
}