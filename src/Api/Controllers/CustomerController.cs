using Application.Services.Customers;
using Application.Services.Customers.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerUseCases _customerService;
        public CustomerController(CustomerUseCases customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var result = await _customerService.Search.Execute(name);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAll.Execute();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerForRequest request)
        {
            var result = await _customerService.CreateCustomer.Execute(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CustomerForRequest request)
        {
            var result = await _customerService.UpdateCustomer.Execute(id,request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteCustomer.Execute(id);
            return Ok(result);
        }

    }
}
