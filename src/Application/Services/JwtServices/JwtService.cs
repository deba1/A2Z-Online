using Application.Interfaces.EncyptionInterfaces;
using Application.Services.JwtServices;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    class JwtService : IAuthenticationService
    {
        private readonly IJwtConfigurationServiceModel _jwtConfigurationServiceModel;

        public JwtService(IJwtConfigurationServiceModel jwtConfigurationServiceModel)
        {
            _jwtConfigurationServiceModel = jwtConfigurationServiceModel;
        }

        public Claim[] Claims { get; set; }

        private Claim[] GenerateClaims(UserCredential user, bool refreshToken = false)
        {
            return Claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString("D")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, refreshToken ? "RefreshToken" : "AccessToken")
            };
        }

        private JwtSecurityToken GetSecurityToken(Claim[] claims, bool refreshToken = false)
        {
            return new JwtSecurityToken(
                issuer: _jwtConfigurationServiceModel.Issuer,
                audience: _jwtConfigurationServiceModel.Audience,
                expires: DateTime.UtcNow.Add(refreshToken ? _jwtConfigurationServiceModel.RefreshTokenValidationTime : _jwtConfigurationServiceModel.AccessTokenValidationTime), // Token validation time.
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(refreshToken ? _jwtConfigurationServiceModel.RefreshKey : _jwtConfigurationServiceModel.Key)), SecurityAlgorithms.HmacSha256)
            );
        }

        public string CreateToken(UserCredential user)
        {
            try
            {
                var claims = GenerateClaims(user);
                var token = GetSecurityToken(claims);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch
            {
                throw;
            }
        }

        public string CreateRefreshToken(UserCredential user)
        {
            try
            {
                var claims = GenerateClaims(user, true);
                var refreshToken = GetSecurityToken(claims, true);

                return new JwtSecurityTokenHandler().WriteToken(refreshToken);
            }
            catch
            {
                throw;
            }
        }

        public List<Claim> GetClaimsFromToken(string token, bool refreshToken = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(refreshToken ? _jwtConfigurationServiceModel.RefreshKey : _jwtConfigurationServiceModel.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _jwtConfigurationServiceModel.Issuer,
                    ValidAudience = _jwtConfigurationServiceModel.Audience,

                    // Set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return jwtToken.Claims.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? VerifyToken(string token)
        {
            try
            {
                var claims = GetClaimsFromToken(token);

                if (claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.AuthenticationMethod))?.Value == "RefreshToken")
                {
                    return null;
                }

                return Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
