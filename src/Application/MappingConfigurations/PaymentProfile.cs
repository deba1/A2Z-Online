using Application.DTOs.EntityDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();
        }
    }
}
