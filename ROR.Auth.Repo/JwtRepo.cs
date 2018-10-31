using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ROR.Auth.Interfaces;
using ROR.DataAccess.Mongo.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ROR.Auth.Repo
{
    public class JwtRepo : ITokenRepo
    {
        private IConfiguration _config;

        public JwtRepo(IConfiguration config)
        {
            _config = config;
        }

        public string createToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.PID),
                new Claim("PersonId", user.AJCP_ID),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
