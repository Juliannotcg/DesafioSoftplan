using CalculaJuros.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Command.Handlers
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return _mediator.Publish(notification, cancellationToken);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return _mediator.Publish(notification, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        public Task<TResult> SendCommand<T, TResult>(T command) where T : ResultedCommand<TResult>
        {
            return _mediator.Send<TResult>(command);
        }
    }
}
