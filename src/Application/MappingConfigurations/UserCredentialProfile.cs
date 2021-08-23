using Application.DTOs.EntityDTOs;
using Application.DTOs.AuthenticationDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfigurations
{
    public class UserCredentialProfile : Profile
    {
        public UserCredentialProfile()
        {
            CreateMap<UserCredentialDTO, UserCredential>();
            CreateMap<UserCredential, UserCredentialDTO>();

            CreateMap<RegisterDTO, UserCredential>();
            CreateMap<UserCredential, RegisterDTO>();
        }
    }
}
