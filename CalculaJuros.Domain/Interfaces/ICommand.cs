using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Interfaces
{
    public interface ICommand : IMessage
    {
        ValidationResult ValidationResult { get; set; }
        bool IsValid();
    }
}
