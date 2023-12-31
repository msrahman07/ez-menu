using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService
    {
        private readonly IConfiguration config;

        public TokenService(IConfiguration config)
        {
            this.config = config;
        }

        public string CreateToken(Restaurant restaurant)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, restaurant.Email!),
                new Claim(ClaimTypes.NameIdentifier, restaurant.Id),
                // new Claim(ClaimTypes.Email, restaurant.Email!),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}