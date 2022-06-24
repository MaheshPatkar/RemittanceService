using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Remittance_Provider
{
    public static class CommonHelper
    {
        public static Guid RetrieveGUID(string input)
        {
            var match = Regex.Match(input, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}");
            if (match.Success)
            {
                return new Guid(match.Value);
            }
            return Guid.Empty;
        }

        public static string GenerateJWTToken(string userName)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mahesh@1994@1994@1994"));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim("Issuer","Mahesh"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName,userName)
            };

                var token = new JwtSecurityToken("Mahesh", "Mahesh", claims, expires: DateTime.Now.AddMinutes(120),
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
