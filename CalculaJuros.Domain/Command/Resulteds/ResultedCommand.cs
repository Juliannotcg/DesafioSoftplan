using CalculaJuros.Domain.Command.Resulteds;
using CalculaJuros.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Command
{
    public abstract class ResultedCommand<T> : ResultedMessage<T>, ICommand
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
