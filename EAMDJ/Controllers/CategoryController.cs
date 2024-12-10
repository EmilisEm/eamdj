using EAMDJ.Dto;
using EAMDJ.Service.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/category")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("by-business/{id}")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategorysByBusinessId(Guid id)
        {
            return Ok(await _service.GetAllProductCategoriesByBusinessIdAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDto>> GetProductCategory(Guid id)
        {
            return Ok(await _service.GetProductCategoryAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(Guid id, ProductCategoryDto productCategory)
        {
            if (id != productCategory.Id)
            {
                return BadRequest();
            }

            await _service.UpdateProductCategoryAsync(id, productCategory);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryDto>> PostProductCategory(ProductCategoryDto productCategory)
        {
            return await _service.CreateProductCategoryAsync(productCategory);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProductCategory(Guid id)
        {
			await _service.DeleteProductCategoryAsync(id);

            return NoContent();
        }
	}
}
