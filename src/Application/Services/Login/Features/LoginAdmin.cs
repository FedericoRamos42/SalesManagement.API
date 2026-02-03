using Application.Result;
using Application.Services.Login.Interfaces;
using Application.Services.Login.Models;
using Domain.Enitites;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Login.Features
{
    public class LoginAdmin
    {
        private readonly IAuthRepository _repository;
        private readonly IPasswordHasher _hasher;
        private readonly IAuthService _authService;
        

        public LoginAdmin(IAuthRepository repository, IPasswordHasher hasher,IAuthService authService)
        {
           _repository = repository; 
           _hasher = hasher;
           _authService = authService;
        }

        public async Task<Result<string>> Execute(LoginRequest request)
        {
            var admin = await _repository.Get(x => x.Email == request.Email);

            if (admin is null)
                return Result<string>.Failure("invalid email");

            if (!_hasher.Verify(request.Password,admin.Password))
                return Result<string>.Failure("invalid password");

            string token = _authService.CreateToken(admin);
            return Result<string>.Succes(token);
        }
    }
}
