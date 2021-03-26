using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublicarEvent<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
