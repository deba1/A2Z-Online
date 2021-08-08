using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class GlobalConfigurationProfile : Profile
    {
        public GlobalConfigurationProfile()
        {
            CreateMap<GlobalConfigurationDTO, GlobalConfiguration>();
            CreateMap<GlobalConfiguration, GlobalConfigurationDTO>();
        }
    }
}
