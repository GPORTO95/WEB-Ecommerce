using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.Messages.ComunMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
