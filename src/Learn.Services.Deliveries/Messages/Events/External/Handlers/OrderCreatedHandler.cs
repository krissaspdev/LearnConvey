using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Deliveries.Messages.Events.External.Handlers
{
    public class OrderCreatedHandler: IEventHandler<OrderCreated>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;

        public OrderCreatedHandler(ILogger<OrderCreatedHandler> logger)
        {
            _logger = logger;
        }
        public async Task HandleAsync(OrderCreated @event)
        {
            _logger.LogInformation($"Received 'order created' event with order id: {@event.OrderId}");
            var deliveryId = Guid.NewGuid();
            _logger.LogInformation($"Starting a delivery with id: {deliveryId}");

            await Task.CompletedTask;
        }
    }
}