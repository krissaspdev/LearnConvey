using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Learn.Services.Deliveries.Messages.Events.External
{
    [Message("orders")]
    public class OrderCreated : IEvent
    {
        public Guid OrderId { get; }

        public OrderCreated(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}