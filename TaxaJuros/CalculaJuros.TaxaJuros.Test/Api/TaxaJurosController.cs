using CalculaJuros.Api.TaxaJuros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.TaxaJuros.Test.Api
{
    [TestClass]
    public class TaxaJurosController : WebApplicationFactory<Startup>
    {
        protected HttpClient _client;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development")
               .UseStartup<Startup>();
            base.ConfigureWebHost(builder);
        }

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
               .UseStartup<Startup>();

            _client = this.CreateClient();
        }

        [TestMethod]
        public async Task Buscando_Taxa_De_Juros_Com_Sucesso()
        {
            var response = await _client.GetAsync("TaxaJuros");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
