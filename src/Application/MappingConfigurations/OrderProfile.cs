using AutoMapper;
using Domain.Entities;
using Application.DTOs;

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
