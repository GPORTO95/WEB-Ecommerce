using MediatR;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.Messages.ComunMessages.DomainEvents
{
    public abstract class DomainEvent : Message, INotification
    {
        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; private set; }
    }
}
