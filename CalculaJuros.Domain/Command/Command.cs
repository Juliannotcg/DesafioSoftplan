using FluentValidation.Results;
using MediatR;

namespace CalculaJuros.Domain.Command
{
    public abstract class Command<T> : IRequest<T>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
