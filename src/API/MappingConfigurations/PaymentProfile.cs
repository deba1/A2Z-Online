using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
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
