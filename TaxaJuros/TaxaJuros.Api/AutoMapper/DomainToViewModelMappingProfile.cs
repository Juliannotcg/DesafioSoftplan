using AutoMapper;
using TaxaJuros.Api.ViewModels;
using TaxaJuros.Domain.Models;

namespace TaxaJuros.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TaxaDeJuros, TaxaDeJurosViewModel>();
        }
    }
}