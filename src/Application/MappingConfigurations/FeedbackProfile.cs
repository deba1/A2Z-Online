using Application.DTOs.EntityDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class FeedbackProfile : Profile 
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackDTO, Feedback>();
            CreateMap<Feedback, FeedbackDTO>();
        }
    }
}
