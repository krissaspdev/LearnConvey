using System;
using Convey.CQRS.Commands;
using Newtonsoft.Json;

namespace Learn.Services.Orders.Messages.Commands
{
    public class CreateOrder : ICommand
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CreateOrder(Guid orderId, Guid customerId)
        {
            OrderId = orderId == Guid.Empty ? Guid.NewGuid() : orderId;
            CustomerId = customerId;
        }
    }
}