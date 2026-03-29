using HogRider.Backend.DTOs;
using HogRider.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace HogRider.Backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService orderService)
        {
            _userService = orderService;
        }

        [HttpGet("{userId}/orders")]
        public async Task<IActionResult> GetUsersOrders(int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid userId");

            var orders = await _userService.GetUserOrdersAsync(userId);

            if (orders == null)
                return NotFound($"User with id {userId} not found");

            return Ok(orders);
        }

        [HttpPost("{userId}/order")]
        public async Task<IActionResult> CreateOrder(
            int userId,
            [FromBody] CreateOrderRequest request)
        {
            if (userId <= 0)
                return BadRequest(new { message = "Invalid userId" });

            try
            {
                var result = await _userService.CreateOrderAsync(userId, request);

                if (!result)
                    return NotFound(new { message = "User not found" });

                TriggerNewRecommendations(userId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private static void TriggerNewRecommendations(int userId)
        {
            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(10);

                var token = Environment.GetEnvironmentVariable("RECOMMENDER_API_KEY");
                if (!string.IsNullOrWhiteSpace(token))
                    http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var url = $"https://svc-recommender-latest.onrender.com/api/users/{userId}/recommendations";
                using var content = new StringContent("{}", Encoding.UTF8, "application/json");

                _ = http.PostAsync(url, content).GetAwaiter().GetResult();
            }
            catch
            {
                // ignore
            }
        }
    }
}
