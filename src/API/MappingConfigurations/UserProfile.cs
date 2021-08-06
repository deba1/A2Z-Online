using Application.DTOs;
using Application.DTOs.AuthenticationDTOs;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
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
