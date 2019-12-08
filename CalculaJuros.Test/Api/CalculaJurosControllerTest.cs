using CalculoJuros.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Test.Api
{
    [TestClass]
    public class CalculaJurosControllerTest : WebApplicationFactory<Startup>
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
   
        [DataTestMethod]
        [DataRow(100, 5)]
        public async Task Calcular_De_Juros_Com_Sucesso(double valorInicial, int meses)
        {
            var response = await _client.GetAsync($"api/CalculaJuros?valorInicial={valorInicial}&meses={meses}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [DataTestMethod]
        [DataRow(100, 5)]
        public async Task Calcular_Taxa_De_Juros_Com_Erro_De_Rota(double valorInicial, int meses)
        {
            var response = await _client.GetAsync($"api/ClaJuros?valorInicial={valorInicial}&meses={meses}");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
