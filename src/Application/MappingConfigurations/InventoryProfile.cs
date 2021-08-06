using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class InventoryProfile : Profile 
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDTO, Inventory>();
            CreateMap<Inventory, InventoryDTO>();
        }
    }
}
