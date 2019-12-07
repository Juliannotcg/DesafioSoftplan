using CalculaJuros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Command.Messages
{
    public class Message : IMessage
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
