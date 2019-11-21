using System.Threading.Tasks;
using Convey.MessageBrokers;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Deliveries.Messages.Commands.Handlers
{
    public class CreateDeliveryHandler
    {
        private readonly IBusPublisher _publisher;
        private readonly ILogger<CreateDeliveryHandler> _logger;

        public CreateDeliveryHandler(IBusPublisher publisher, ILogger<CreateDeliveryHandler> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }
        
        public async Task HandleAsync(CreateDelivery command)
        {
            _logger.LogInformation($"Created an order with id: {command.CustomerId}, customer: {command.CustomerId}.");
            //tu zapis do bazy
            
            //await _publisher.PublishAsync(new OrderCreated(command.OrderId));
            await Task.CompletedTask;
        }
    }
}