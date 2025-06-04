using Application.Services.Sales;
using Application.Services.Sales.Features;
using Application.Services.Sales.Models.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _services;

        public SaleController(SaleService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAllSale.Execute();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleRequest request)
        {
            var result = _services.CreateSale.Execute(request);
            return Ok(result);
        }

        
        
    }
}
