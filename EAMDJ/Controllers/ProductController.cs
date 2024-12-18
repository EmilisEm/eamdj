using EAMDJ.Dto.ProductDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/product")]
	[ApiController]
	[Authorize]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _service;
		private readonly IAuthService _authService;
		public ProductController(IProductService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-product-category/{id}")]
		public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsByProductCategoryId(Guid id)
		{
			var products = await _service.GetAllProductsByProductCategoryIdAsync(id);
			if (products.Any() && !_authService.AuthorizeForBusiness(products.Select(it => it.BusinessId).First()))
			{
				return Forbid();
			}

			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductResponseDto>> GetProduct(Guid id)
		{
			var product = await _service.GetProductAsync(id);
			if (!_authService.AuthorizeForBusiness(product.BusinessId))
			{
				return Forbid();
			}

			return Ok(product);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(Guid id, ProductUpdateDto product)
		{
			var original = await _service.GetProductAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(original.BusinessId))
			{
				return Forbid();
			}

			await _service.UpdateProductAsync(id, product);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ProductResponseDto>> PostProduct(ProductCreateDto product)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			return await _service.CreateProductAsync(product);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			var original = await _service.GetProductAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(original.BusinessId))
			{
				return Forbid();
			}

			await _service.DeleteProductAsync(id);

			return NoContent();
		}

	}
}
