using AutoMapper;
using Domain.Entities;
using Application.DTOs.EntityDTOs;

namespace Application.MappingConfigurations
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
