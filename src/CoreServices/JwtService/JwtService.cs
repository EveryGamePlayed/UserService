using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Text;
using CoreServices.JwtService.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;

namespace CoreServices.JwtService
{
    public class JwtService
    {
        private readonly JwtConfig _jwtConfig;

        public JwtService(IOptions<JwtConfig> jwtConfigOptions)
        {
            _jwtConfig = jwtConfigOptions.Value;
        }


        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };


            var token = new JwtSecurityToken(_jwtConfig.Issuer, 
                _jwtConfig.Audience,claims, 
                expires: DateTime.Now.AddHours(1), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}