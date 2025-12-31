using Application.Services.Producto;
using Application.Services.Products.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductUseCases _productService;
        public ProductController(ProductUseCases productService)
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

        [HttpPut ("{id}/stock")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] UpdateStockRequest request)
        {
            var result = await _productService.UpdateProductStock.Execute(id, request);
            return Ok(result);
        }

        [HttpPut ("{id}/price")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] UpdatePriceRequest request)
        {
            var result = await _productService.UpdateProductPrice.Execute(id, request);
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
