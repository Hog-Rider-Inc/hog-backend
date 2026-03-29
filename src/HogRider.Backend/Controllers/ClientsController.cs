using HogRider.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HogRider.Backend.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController: ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService orderService)
        {
            _clientService = orderService;
        }

        [HttpGet("{clientId}/orders")]
        public async Task<IActionResult> GetClientOrders(int clientId)
        {
            var orders = await _clientService.GetClientOrdersAsync(clientId);
            return Ok(orders);
        }
    }
}
