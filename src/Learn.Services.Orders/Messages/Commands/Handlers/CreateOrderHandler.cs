using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using Learn.Services.Orders.Messages.Events;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Orders.Messages.Commands.Handlers
{
    public class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly IBusPublisher _publisher;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(IBusPublisher publisher, ILogger<CreateOrderHandler> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }
        
        public async Task HandleAsync(CreateOrder command)
        {
            _logger.LogInformation($"Created an order with id: {command.OrderId}, customer: {command.CustomerId}.");
            //tu zapis do bazy
            
            await _publisher.PublishAsync(new OrderCreated(command.OrderId));
            //await Task.CompletedTask;
        }
    }
}