using Domain.Entities;

namespace Application.DTOs.AuthenticationDTOs
{
    public class LoginResponseDTO
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
    }
}
