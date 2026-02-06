using Application.Services.Login.Interfaces;
using Domain.Enitites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class AdminSeeder
    {
        
        private readonly IPasswordHasher _hasher;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AdminSeeder( IPasswordHasher hasher, IConfiguration configuration, ApplicationDbContext context)
        {
            _hasher = hasher;
            _configuration = configuration;
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await _context.Admins.AnyAsync())
                return;

            var email = _configuration["Admin:Email"];
            var password = _configuration["Admin:Password"];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Admin Credentials are not Configured");

            var passwordHash = _hasher.Hash(password);

            var admin = new Admin
            {
                Email = email,
                Password = passwordHash,
            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();



        }
    }
}
