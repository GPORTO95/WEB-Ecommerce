using NerdStore.Core.Messages;
using NerdStore.Core.Messages.ComunMessages.DomainEvents;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        public Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}
