using Application.DTOs;
using Application.DTOs.AuthenticationDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<RegisterDTO, User>();
            CreateMap<User, RegisterDTO>();
        }
    }
}
