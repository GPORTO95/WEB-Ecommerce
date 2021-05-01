using MediatR;
using NerdStore.Core.Data.EvetnSourcing;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.ComunMessages.DomainEvents;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public MediatorHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);

            if (!evento.GetType().BaseType.Name.Equals("DomainEvent"))
                await _eventSourcingRepository.SalvarEvento(evento);
        }

        public Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            return _mediator.Publish(notificacao);
        }

        public Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            return _mediator.Publish(notificacao);
        }
    }
}
