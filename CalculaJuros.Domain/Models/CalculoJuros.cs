using System;

namespace CalculaJuros.Domain.Models
{
    public class CalculoJuros
    {
        public decimal Taxa { get; private set; }
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }

        private decimal _valorCalculado;
        private int _casasDecimais = 2;

        public CalculoJuros(decimal taxa, decimal valorInicial, int meses)
        {
            Taxa = taxa;
            ValorInicial = valorInicial;
            Meses = meses;
            _valorCalculado = 0m;
        }

        public decimal Calcular()
        {
            var aux = (decimal)Math.Pow(decimal.ToDouble(Taxa) + 1, Meses);
            _valorCalculado = ValorInicial * aux;

            decimal step = (decimal)Math.Pow(10, _casasDecimais);
            decimal tmp = Math.Truncate(step * _valorCalculado);
            _valorCalculado = tmp / step;

            return _valorCalculado;
        }
    }
}
