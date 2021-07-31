using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace API.MappingConfigurations
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
