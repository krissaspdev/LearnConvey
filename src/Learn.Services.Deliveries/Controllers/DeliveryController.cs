using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Learn.Services.Deliveries.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Deliveries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public DeliveryController(ILogger<DeliveryController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }
        
        //api/delivery
        [HttpPost]
        public async Task<ActionResult> Post(CreateDelivery command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
            //return CreatedAtAction(nameof(Get), new {orderId = command.OrderId}, null);
        }
    }
}