using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using TaxaJuros.Api;
using TaxaJuros.Test.Config;

namespace TaxaJuros.Test.Api
{
    [TestClass]
    public class TaxaJurosControllerTest : IntegrationTestInitializer<Startup>
    {
  
        [TestMethod]
        public async Task Buscando_Taxa_De_Juros_Com_Sucesso()
        {
            var response = await _client.GetAsync("api/TaxaJuros");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
