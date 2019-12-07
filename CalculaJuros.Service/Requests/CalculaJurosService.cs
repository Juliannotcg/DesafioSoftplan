using CalculaJuros.Service.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Service.Requests
{
    public class CalculaJurosService
    {

        public void ConsumingApi()
        {
            var client = new RestClient("https://localhost:44322/");
            var request = new RestRequest("api/TaxaJuros", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            TaxaJurosViewModel taxaJuros = JsonConvert.DeserializeObject<TaxaJurosViewModel>(content);
        }
    }
}
