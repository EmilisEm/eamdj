using EAMDJ.Dto.ProductDto;
using EAMDJ.Service.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _service;
		public ProductController(IProductService service)
		{
			_service = service;
		}

		[HttpGet("by-product-category/{id}")]
		public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsByProductCategoryId(Guid id)
		{
			return Ok(await _service.GetAllProductsByProductCategoryIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductResponseDto>> GetProduct(Guid id)
		{
			return Ok(await _service.GetProductAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(Guid id, ProductUpdateDto product)
		{
			await _service.UpdateProductAsync(id, product);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ProductResponseDto>> PostProduct(ProductCreateDto product)
		{
			return await _service.CreateProductAsync(product);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			await _service.DeleteProductAsync(id);

			return NoContent();
		}

	}
}
