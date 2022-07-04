using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Remittance_Provider
{
    public static class CommonHelper
    {
        public static string GenerateJWTToken(IConfiguration configuration)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("key")));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                  new Claim(ClaimTypes.Name,configuration["user:userName"]),
                  new Claim(ClaimTypes.Email,configuration["user:email"]),
                  new Claim(ClaimTypes.Role,configuration["user:role"])
                };

                var token = new JwtSecurityToken(
                      issuer: configuration.GetValue<string>("Issuer"),
                      audience: configuration.GetValue<string>("Audience"),
                      claims: claims,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
