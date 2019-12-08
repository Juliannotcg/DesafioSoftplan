using AutoMapper;
using CalculaJuros.Domain.Command;

namespace CalculoJuros.Api.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<CalculoJurosCommandCalcular, CalculaJuros.Domain.Models.CalculoJuros>();
        }
    }
}