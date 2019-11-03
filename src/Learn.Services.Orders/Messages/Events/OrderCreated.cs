using System;
using Convey.CQRS.Events;

namespace Learn.Services.Orders.Messages.Events
{
    public class OrderCreated : IEvent
    {
        public Guid OrderId { get; }

        public OrderCreated(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}