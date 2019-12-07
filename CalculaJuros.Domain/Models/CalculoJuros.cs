using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Domain.Models
{
    public class CalculoJuros
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public int Tempo { get; set; }
    }
}
