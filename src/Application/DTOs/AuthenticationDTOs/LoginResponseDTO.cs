using Domain.Enums;

namespace Application.DTOs.AuthenticationDTOs
{
    public class LoginResponseDTO
    {
        public RoleResponseEnum Role { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
