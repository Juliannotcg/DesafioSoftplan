using AutoMapper;
using CalculaJuros.Domain.Command;
using CalculaJuros.Domain.Interfaces;
using CalculoJuros.Api.AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace CalculaJuros.Test.Command
{
    [TestClass]
    public class CommandHandler
    {
        private MapperConfiguration _config = AutoMapperConfiguration.RegisterMappings();
        private IMapper _mapper;

        private readonly decimal resultadoFinal = 262.75m;


        [TestInitialize]
        public void Setup()
        {
            _mapper = _config.CreateMapper();
        }

        [TestMethod]
        public void CalcularJuros_CommandHandler_Com_Sucesso()
        {
            var command = new Mock<CalculoJurosCommandCalcular>();
            command.Object.Taxa = 0.01m;
            command.Object.ValorInicial = 250;
            command.Object.Meses = 5;

            IRequestHandler<CalculoJurosCommandCalcular, decimal> commandHandler =
                new CalculoJurosCommandHandler(_mapper);

            Task<decimal> resultado = commandHandler.Handle(command.Object, new CancellationToken(false));
            Assert.AreEqual(resultado.Result, resultadoFinal);
        }

        [TestMethod]
        public void CalcularJuros_CommandHandler_Com_Erro()
        {
            var command = new Mock<CalculoJurosCommandCalcular>();
            command.Object.Taxa = 0.01m;
            command.Object.ValorInicial = 50;
            command.Object.Meses = 5;

            IRequestHandler<CalculoJurosCommandCalcular, decimal> commandHandler =
                new CalculoJurosCommandHandler(_mapper);

            Task<decimal> resultado = commandHandler.Handle(command.Object, new CancellationToken(false));
            Assert.AreNotEqual(resultado.Result, resultadoFinal);
        }
    }
}
