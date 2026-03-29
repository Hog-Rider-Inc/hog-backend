using HogRider.Backend.DTOs;
using HogRider.Backend.Services;
using Microsoft.AspNetCore.Mvc;

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

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
