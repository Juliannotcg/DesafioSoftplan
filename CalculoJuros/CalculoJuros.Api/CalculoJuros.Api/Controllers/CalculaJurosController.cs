using CalculaJuros.Domain.Command;
using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculoJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly IMediatorHandler _bus;
        private readonly ICalcularJurosService _calcularJurosService;

        public CalculaJurosController(IMediatorHandler bus,
                                      ICalcularJurosService calcularJurosService)
        {
            _bus = bus;
            _calcularJurosService = calcularJurosService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<decimal>> CalcularJuros([FromQuery]decimal valorInicial,
                                                               [FromQuery]int meses)

        {

            var request = await _calcularJurosService.CalcularJurosServiceAsync(valorInicial, meses);

            var task = await _bus.SendCommand<CalculoJurosCommandCalcular, decimal>(request);
            return Ok(task);
        }
    }
}
