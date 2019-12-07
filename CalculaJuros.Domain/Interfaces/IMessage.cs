using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Interfaces
{
    public interface IMessage : IRequest
    {
        string MessageType { get; }
        Guid AggregateId { get; }
    }
}
