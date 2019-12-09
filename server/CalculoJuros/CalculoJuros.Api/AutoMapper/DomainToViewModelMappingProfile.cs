using AutoMapper;
using CalculaJuros.Service.ViewModels;

namespace CalculoJuros.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CalculaJuros.Domain.Models.CalculoJuros, CalculaJurosViewModel>();
        }
    }
}