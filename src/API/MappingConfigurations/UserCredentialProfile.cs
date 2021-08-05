using Application.DTOs;
using Application.DTOs.AuthenticationDTOs;
using AutoMapper;
using Domain.Entities;

namespace API.MappingConfigurations
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
