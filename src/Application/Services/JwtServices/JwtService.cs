using Application.Interfaces;
using Application.Services.JwtServices;
using Domain.Entities;
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

        public Claim[] Claims { get; set; }

        private Claim[] GenerateClaims(User user)
        {
            return Claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

        public string CreateToken(User user)
        {
            try
            {
                GenerateClaims(user);
                var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    expires: DateTime.UtcNow.AddMinutes(ValidationTime), // Token validation time.
                    claims: Claims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)), SecurityAlgorithms.HmacSha256)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? VerifyToken(string token)
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

                return Convert.ToInt32(jwtToken.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
