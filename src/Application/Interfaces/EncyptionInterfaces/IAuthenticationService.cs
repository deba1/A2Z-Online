using Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Interfaces.EncyptionInterfaces
{
    public interface IAuthenticationService
    {
        string CreateToken(UserCredential user);
        string CreateRefreshToken(UserCredential user);
        int? VerifyToken(string token);
        List<Claim> GetClaimsFromToken(string token, bool refreshToken = false);
    }
}
