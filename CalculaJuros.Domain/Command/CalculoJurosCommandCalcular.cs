using CalculaJuros.Domain.Command.CommandValidations;
using MediatR;

namespace CalculaJuros.Domain.Command
{
    public class CalculoJurosCommandCalcular : ResultedCommand<decimal>
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
