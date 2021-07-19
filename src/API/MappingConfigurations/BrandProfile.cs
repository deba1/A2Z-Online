using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDTO, Brand>();
            CreateMap<Brand, BrandDTO>();
        }
    }
}
