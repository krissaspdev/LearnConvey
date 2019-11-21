using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Learn.Services.Orders.Messages.Events.External
{
    [Message("deliveries")]
    public class DeliveryStarted : IEvent
    {
        public Guid DeliveryId { get; }

        public DeliveryStarted(Guid deliveryId)
        {
            DeliveryId = deliveryId;
        }
    }
}