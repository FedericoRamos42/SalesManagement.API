using Application.Services.Login;
using Application.Services.Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCases _services;

        public AuthController(LoginUseCases services)
        {
            _services = services;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result =  await _services.LoginAdmin.Execute(request);
            return Ok(result);
        }
    }
}
