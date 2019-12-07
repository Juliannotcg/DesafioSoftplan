using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
namespace TaxaJuros.XUnitTest.Integration
{
    public class TaxaJurosControllerIntegrationTest
    {
        public TaxaJurosControllerIntegrationTest()
        {
            Environment.CriarServidor();
        }

        [Fact(DisplayName = "Evento registrado com sucesso")]
        [Trait("Category", "Testes de integração API")]
        public async Task TaxaJurosController_Retornar_Taxa_De_Juros()
        {

            // Act
            var response = await Environment.Server
                .CreateRequest("api/TaxaJuros").GetAsync();


        }
    }
}
