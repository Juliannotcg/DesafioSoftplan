using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxaJuros.Api.ViewModels;
using TaxaJuros.Domain.Interface;

namespace TaxaJuros.Api.Controllers
{
    [Route("api/TaxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        private readonly IMapper _mapper;

        public TaxaJurosController(ITaxaJurosRepository taxaJurosRepository, IMapper mapper)
        {
            _taxaJurosRepository = taxaJurosRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<TaxaDeJurosViewModel> Get() => await Task.Run(() =>
        _mapper.Map<TaxaDeJurosViewModel>(_taxaJurosRepository.GetTaxaJuros()));
    }
}
