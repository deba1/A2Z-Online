using AutoMapper;
using Application.DTOs.EntityDTOs;
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
