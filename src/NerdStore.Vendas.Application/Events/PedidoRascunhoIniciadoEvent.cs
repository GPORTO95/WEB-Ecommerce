using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event
    {
        public PedidoRascunhoIniciadoEvent(Guid clientId, Guid pedidoId)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
        }

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
    }
}
