using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using TaxaJuros.Api.Controllers;
using TaxaJuros.Domain.Interface;
using TaxaJuros.Api.ViewModels;
using System.Threading.Tasks;

namespace TaxaJuros.XUnitTest.Api
{
    public class TaxaJurosControlllerTest
    {
        public TaxaJurosController taxaJurosController { get; set; }
        public TaxaDeJurosViewModel taxaDeJurosViewModel { get; set; }
        public Mock<ITaxaJurosRepository> mockRepository { get; set; }
        public Mock<IMapper> mockMapper { get; set; }

        public TaxaJurosControlllerTest()
        {
            mockMapper = new Mock<IMapper>();
            mockRepository = new Mock<ITaxaJurosRepository>();
            taxaDeJurosViewModel = new TaxaDeJurosViewModel();

            taxaJurosController = new TaxaJurosController(
                mockRepository.Object,
                mockMapper.Object);
        }


        //[Fact(DisplayName = "Calcular juros")]
        //[Trait("Category", "Calculo Taxa Controller")]
        //public async Task EventosController_RegistrarEvento_RetornarComErrosDeModelState()
        //{
        //    // Arrange
        //    mockMapper.Setup(m => m.Map<TaxaDeJurosViewModel>(taxaDeJurosViewModel)).Returns(taxaDeJurosViewModel);


        //    var ret =  await taxaJurosController.Get();
        //    // Arrange
        //    var resultado = mockMapper.Object.Map<TaxaDeJurosViewModel>(mockRepository.Object.GetTaxaJuros());
        //    Assert.Equal("", "");

        //    return new Task<TaxaDeJurosViewModel>;
        //}
    }
}
