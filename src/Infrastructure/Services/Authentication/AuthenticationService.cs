using Application.Services.Login.Models;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Application.Services.Login.Interfaces;

namespace Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IAuthRepository repository,IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        
        public string CreateToken(LoginRequest userLogin) // pasar el admin;
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,userLogin.Email) //agregar otro claims nombre identificador con el id.

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]!)
                );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
