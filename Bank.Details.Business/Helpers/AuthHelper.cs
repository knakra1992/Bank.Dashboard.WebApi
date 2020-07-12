using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Bank.Details.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Bank.Details.Business.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IAuthRepo _authRepo;

        private readonly IConfiguration _configuration;

        public AuthHelper(IAuthRepo authRepo, IConfiguration configuration)
        {
            _authRepo = authRepo;
            _configuration = configuration;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> AuthenticateUser(string userName, string password)
        {
            var user = await _authRepo.AuthenticateUser<User>(userName, password);

            if (user != null && user.Id > 0)
                return GenerateJwtToken(user);

            return string.Empty;
        }
    }
}
