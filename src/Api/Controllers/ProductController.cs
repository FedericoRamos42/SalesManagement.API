using Application.Services.Producto;
using Application.Services.Producto.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetProduct.Execute(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProduct.Execute();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.CreateProduct.Execute(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProduct.Execute(id);
            return Ok(result);
        }
        
    }
}
