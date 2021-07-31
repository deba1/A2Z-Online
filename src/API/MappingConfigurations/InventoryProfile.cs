using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace API.MappingConfigurations
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
