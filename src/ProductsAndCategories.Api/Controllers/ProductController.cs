using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Business.DTOs.Category;
using ProductsAndCategories.Business.DTOs.Product;
using ProductsAndCategories.Business.Services.Contracts;
using ProductsAndCategories.Business.Services.Implementation;

namespace ProductsAndCategories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetWithCategory")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var result = await _productService.GetWithCategoryAsync();

            return Ok(result);
        }

        [HttpGet("GetByCategoryId/{categoryId:int}")]
        public async Task<IActionResult> GetByCategoryIdAsync([FromRoute] int categoryId)
        {
            var result = await _productService.GetByCategoryIdAsync(categoryId);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateDto productCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _productService.CreateAsync(productCreateDto);

            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductUpdateDto productUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(productUpdateDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);

            return Ok();
        }
    }
}
