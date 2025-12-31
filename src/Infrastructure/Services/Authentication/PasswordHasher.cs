using Application.Services.Login.Interfaces;
using Domain.Enitites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<Admin> _hasher = new();
        public string Hash(string password)
        {
            return _hasher.HashPassword(null!, password);
            
        }

        public bool Verify(string password, string passwordHash)
        {
            var result = _hasher.VerifyHashedPassword(null!, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
