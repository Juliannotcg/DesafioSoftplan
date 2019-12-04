using AutoMapper;
using CalculaJuros.Api.TaxaJuros.ViewModels;
using CalculaJuros.TaxaJuros.Domain.Models;

namespace CalculaJuros.Api.TaxaJuros.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TaxaDeJuros, TaxaDeJurosViewModel>();
        }
    }
}