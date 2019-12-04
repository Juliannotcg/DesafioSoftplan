using CalculaJuros.TaxaJuros.Domain.Models;
using System;

namespace CalculaJuros.TaxaJuros.Domain.Interfaces
{
    public interface ITaxaJurosRepository : IDisposable
    {
        TaxaDeJuros GetTaxaJuros();
    }
}
