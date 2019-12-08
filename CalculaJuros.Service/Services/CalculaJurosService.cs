using CalculaJuros.Domain.Command;
using CalculaJuros.Service.Interfaces;
using CalculaJuros.Service.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace CalculaJuros.Service.Requests
{
    public class CalculaJurosService : ICalcularJurosService
    {

        public async Task<CalculoJurosCommandCalcular> CalcularJurosServiceAsync(decimal valorInicial, int meses)
        {
            var taxaJuros = await Request();

            var command = new CalculoJurosCommandCalcular
            {
                Taxa = taxaJuros.Juros,
                ValorInicial = valorInicial,
                Meses = meses
            };

            return await Task.FromResult(command);
        }

        public async Task<TaxaJurosViewModel> Request()
        {
            var client = new RestClient("http://localhost:5001/");
            var request = new RestRequest("api/TaxaJuros", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return await Task.FromResult(JsonConvert.DeserializeObject<TaxaJurosViewModel>(content));
        }
    }
}
