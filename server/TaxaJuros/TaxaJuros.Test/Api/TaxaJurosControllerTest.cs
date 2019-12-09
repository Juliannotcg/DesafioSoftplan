using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxaJuros.Api;

namespace TaxaJuros.Test.Api
{
    [TestClass]
    public class TaxaJurosControllerTest : WebApplicationFactory<Startup>
    {
        protected HttpClient _client;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
               .UseStartup<Startup>();
            base.ConfigureWebHost(builder);
        }

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
               .UseStartup<Startup>();

            _client = this.CreateClient();
        }

        [TestMethod]
        public async Task Buscando_Taxa_De_Juros_Com_Sucesso()
        {
            var response = _client.GetAsync("api/TaxaJuros").Result.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, response);
        }

        [TestMethod]
        public async Task Buscando_Taxa_De_Juros_Com_Erro_De_Rota()
        {
            var response = _client.GetAsync("api/T=aJuros").Result.StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, response);
        }
    }
}
