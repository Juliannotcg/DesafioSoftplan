using System;
using TaxaJuros.Domain.Models;

namespace TaxaJuros.Domain.Interface
{
    public interface ITaxaJurosRepository
    {
        TaxaDeJuros GetTaxaJuros();
    }
}
