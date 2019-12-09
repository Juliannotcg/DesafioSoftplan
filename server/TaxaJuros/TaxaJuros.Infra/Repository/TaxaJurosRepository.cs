using System;
using TaxaJuros.Domain.Interface;
using TaxaJuros.Domain.Models;

namespace TaxaJuros.Infra.Repository
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        public TaxaDeJuros GetTaxaJuros() => new TaxaDeJuros { Juros = (1 / 100m) };
    }
}
