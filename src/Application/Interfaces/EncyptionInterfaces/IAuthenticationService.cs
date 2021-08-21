using Domain.Entities;

namespace Application.Interfaces.EncyptionInterfaces
{
    public interface IAuthenticationService
    {
        string CreateToken(User user);
        int? VerifyToken(string token);
    }
}
