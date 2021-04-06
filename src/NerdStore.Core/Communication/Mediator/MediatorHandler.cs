using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            return _mediator.Publish(notificacao);
        }
    }
}
