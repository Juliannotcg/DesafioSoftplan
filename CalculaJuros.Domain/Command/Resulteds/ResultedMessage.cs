using CalculaJuros.Domain.Command.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Command.Resulteds
{
    public abstract class ResultedMessage<T> : Message, IRequest<T>
    {
    }
}
