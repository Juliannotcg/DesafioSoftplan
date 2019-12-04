using CalculaJuros.TaxaJuros.Domain.Interfaces;
using CalculaJuros.TaxaJuros.Domain.Models;
using System;

namespace CalculaJuros.TaxaJuros.Infrastructure.Repository
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TaxaDeJuros GetTaxaJuros() => new TaxaDeJuros { Juros = (1 / 100m) };
    }
}
