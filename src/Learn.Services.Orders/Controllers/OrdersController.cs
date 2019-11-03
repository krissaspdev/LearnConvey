using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Learn.Services.Orders.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController: ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public OrdersController(ILogger<OrdersController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }
        
        //api/orders
        [HttpPost]
        public async Task<ActionResult> Post(CreateOrder command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
            //return CreatedAtAction(nameof(Get), new {orderId = command.OrderId}, null);
        }
    }
}