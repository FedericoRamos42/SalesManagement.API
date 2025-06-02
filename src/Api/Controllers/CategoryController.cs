using Application.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAll.Execute();
            return Ok(result);
        }

        [HttpPost]




    }
}
