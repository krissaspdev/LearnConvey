using System;
using Convey.CQRS.Commands;

namespace Learn.Services.Deliveries.Messages.Commands
{
    public class CreateDelivery: ICommand
    {
        public Guid CustomerId { get; }

        public CreateDelivery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}