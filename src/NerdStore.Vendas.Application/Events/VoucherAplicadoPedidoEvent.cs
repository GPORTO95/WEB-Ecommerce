using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public VoucherAplicadoPedidoEvent(Guid clientId, Guid pedidoId, Guid voucherId)
        {
            ClientId = clientId;
            PedidoId = pedidoId;
            VoucherId = voucherId;
        }

        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid VoucherId { get; private set; }
    }
}
