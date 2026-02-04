using Application.Services.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardUseCases _service;
        public DashboardController(DashboardUseCases service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get.Execute();
            if(!result.IsSucces)
            {
                return BadRequest(new{ errors = result.Errors});
            }
            return Ok(result.Value);
        }
    }
}
