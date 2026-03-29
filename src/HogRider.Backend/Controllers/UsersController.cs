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
    }
}
