using Application.DTOs.EntityDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
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
