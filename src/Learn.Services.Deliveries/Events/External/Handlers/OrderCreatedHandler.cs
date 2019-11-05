using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Deliveries.Events.External.Handlers
{
    public class OrderCreatedHandler: IEventHandler<OrderCreated>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;
        private readonly IBusPublisher _publisher;

        public OrderCreatedHandler(ILogger<OrderCreatedHandler> logger, IBusPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
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