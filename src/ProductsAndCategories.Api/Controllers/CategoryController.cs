using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Business.DTOs.Category;
using ProductsAndCategories.Business.Services.Contracts;

namespace ProductsAndCategories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _categoryService.CreateAsync(categoryCreateDto);

            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _categoryService.UpdateAsync(categoryUpdateDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
