using FluentValidation;

namespace CalculaJuros.Domain.Command.CommandValidations
{
    public class CalculoJurosCommandCalcularValidation : AbstractValidator<CalculoJurosCommandCalcular>
    {
        public CalculoJurosCommandCalcularValidation()
        {
            RuleFor(c => c.ValorInicial)
                .GreaterThan(0)
                .WithMessage(string.Format("", "Valor Inicial", 0.01m));


            RuleFor(c => c.Meses)
                .GreaterThan(0)
                .WithMessage(string.Format("", "Meses", 1));
        }
    }
}
