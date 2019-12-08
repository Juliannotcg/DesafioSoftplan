namespace CalculaJuros.Domain.Command
{
    public class CalculoJurosCommandCalcular : ResultedCommand<decimal>
    {
        public decimal Taxa { get; set; }
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
