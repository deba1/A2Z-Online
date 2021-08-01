using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        string CreateToken(Claim[] claim);
        string VerifyToken(string token);
    }
}
