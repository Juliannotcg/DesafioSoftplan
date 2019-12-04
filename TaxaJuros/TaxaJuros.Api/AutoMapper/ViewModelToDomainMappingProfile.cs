using AutoMapper;
using TaxaJuros.Api.ViewModels;
using TaxaJuros.Domain.Models;

namespace TaxaJuros.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TaxaDeJurosViewModel, TaxaDeJuros>();
        }
    }
}