using CalculaJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCode : ControllerBase
    {

        private readonly ICalculaJurosRepository _calculaJurosRepository;

        public ShowMeTheCode(ICalculaJurosRepository calculaJurosRepository)
        {
            _calculaJurosRepository = calculaJurosRepository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_calculaJurosRepository.GetRepositoryGit());
    }
}
