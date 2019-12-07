using CalculaJuros.Domain.Command;
using MediatR;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Interfaces
{
    public interface IMediatorHandler : IMediator
    {
        Task<TResult> SendCommand<T, TResult>(T command) where T : Command<TResult>;
    }
}
