using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
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
