using Application.Interfaces;
using Application.Services.JwtServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    class JwtService : JwtConfigurationServiceModel, IAuthenticationService
    {
        public JwtService(IConfiguration config) : base(config)
        {

        }

        public string CreateToken(Claim[] claim)
        {
            try
            {
                var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    expires: DateTime.UtcNow.AddMinutes(ValidationTime), // Token validation time.
                    claims: claim,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)), SecurityAlgorithms.HmacSha256)
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,

                    // Set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "userId").Value;

                // Return user id from JWT token if validation successful
                return userId;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
