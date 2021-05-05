using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using NerdStore.Vendas.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Web.App.MVC.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IPedidoQueries pedidoQueries,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _pedidoQueries = pedidoQueries;
        }

        [Route("meus-pedidos")]
        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoQueries.ObterPedidosCliente(ClienteId);
            return View(pedidos);
        }
    }
}
