using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Service.ViewModels
{
    public class CalculaJurosViewModel
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal TaxaJuros { get; set; }
        public int Tempo { get; set; }
    }
}
