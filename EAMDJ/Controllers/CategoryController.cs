using EAMDJ.Dto.ProductCategoryDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/category")]
	[ApiController]
	[Authorize]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _service;
		private readonly IAuthService _authService;
		public CategoryController(ICategoryService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<ProductCategoryResponseDto>>> GetProductCategorysByBusinessId(Guid id)
		{
			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}
			return Ok(await _service.GetAllProductCategoriesByBusinessIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductCategoryResponseDto>> GetProductCategory(Guid id)
		{
			var category = await _service.GetProductCategoryAsync(id);
			if (!_authService.AuthorizeForBusiness(category.Id))
			{
				return Forbid();
			}
			return Ok(category);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutProductCategory(Guid id, ProductCategoryUpdateDto productCategory)
		{
			var category = await _service.GetProductCategoryAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(category.BusinessId))
			{
				return Forbid();
			}

			await _service.UpdateProductCategoryAsync(id, productCategory);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ProductCategoryResponseDto>> PostProductCategory(ProductCategoryCreateDto productCategory)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(productCategory.BusinessId))
			{
				return Forbid();
			}

			return await _service.CreateProductCategoryAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteProductCategory(Guid id)
		{
			var category = await _service.GetProductCategoryAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			var service = await _service.GetProductCategoryAsync(id);
			if (!_authService.AuthorizeForBusiness(category.Id))
			{
				return Forbid();
			}

			await _service.DeleteProductCategoryAsync(id);

			return NoContent();
		}
	}
}
