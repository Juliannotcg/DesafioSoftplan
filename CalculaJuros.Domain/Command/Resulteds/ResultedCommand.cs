using MediatR;

namespace CalculaJuros.Domain.Command
{
    public abstract class ResultedCommand<T> : IRequest<T>
    {
    }
}
