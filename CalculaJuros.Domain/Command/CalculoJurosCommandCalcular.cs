using CalculaJuros.Domain.Command.CommandValidations;

namespace CalculaJuros.Domain.Command
{
    public class CalculoJurosCommandCalcular : Command<decimal>
    {
        public decimal Taxa { get; set; }
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CalculoJurosCommandCalcularValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
