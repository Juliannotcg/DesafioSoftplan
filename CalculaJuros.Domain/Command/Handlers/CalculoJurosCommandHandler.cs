using AutoMapper;
using CalculaJuros.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Command
{
    public class CalculoJurosCommandHandler : IRequestHandler<CalculoJurosCommandCalcular, decimal>
    {

        private readonly IMapper _mapper;

        public CalculoJurosCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<decimal> Handle(CalculoJurosCommandCalcular request, CancellationToken cancellationToken)
        {
            var calculo = _mapper.Map<CalculoJuros>(request);
            var retorno = calculo.Calcular();

            return Task.FromResult(retorno);
        }
    }
}
