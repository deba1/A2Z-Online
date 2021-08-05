using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Claim[] Claims { get; set; }
        string CreateToken(User user);
        int? VerifyToken(string token);
    }
}
