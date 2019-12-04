using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace TaxaJuros.Test.Config
{
    public class IntegrationTestInitializer<T> : WebApplicationFactory<T>
        where T : class
    {
        protected HttpClient _client;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
               .UseStartup<T>();
            base.ConfigureWebHost(builder);
        }

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
               .UseStartup<T>();

            _client = this.CreateClient();
        }
    }
}
