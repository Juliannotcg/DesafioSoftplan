using AutoMapper;
using CalculaJuros.Service.ViewModels;

namespace CalculoJuros.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CalculaJurosViewModel, CalculaJuros.Domain.Models.CalculoJuros>();
        }
    }
}