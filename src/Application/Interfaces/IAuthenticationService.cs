using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        string CreateToken(User user);
        int? VerifyToken(string token);
    }
}
