using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
