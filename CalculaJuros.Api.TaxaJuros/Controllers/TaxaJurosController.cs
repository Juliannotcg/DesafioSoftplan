using AutoMapper;
using CalculaJuros.Api.TaxaJuros.ViewModels;
using CalculaJuros.TaxaJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.Api.TaxaJuros.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<TaxaDeJurosViewModel> Get() => await Task.Run(() => _mapper.Map<TaxaDeJurosViewModel>(_taxaJurosRepository.GetTaxaJuros()));
    }
}
