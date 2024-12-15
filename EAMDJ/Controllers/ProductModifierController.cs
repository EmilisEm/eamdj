using EAMDJ.Dto.ProductModifierDto;
using EAMDJ.Service.ProductModifierService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/product-modifier")]
	[ApiController]
	public class ProductModifierController : ControllerBase
	{
		private readonly IProductModifierService _service;
		public ProductModifierController(IProductModifierService service)
		{
			_service = service;
		}

		[HttpGet("by-product/{id}")]
		public async Task<ActionResult<IEnumerable<ProductModifierResponseDto>>> GetProductModifiersByBusinessId(Guid id)
		{
			return Ok(await _service.GetAllProductModifiersByProductIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductModifierResponseDto>> GetProductModifier(Guid id)
		{
			return Ok(await _service.GetProductModifierAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutProductModifier(Guid id, ProductModifierUpdateDto productCategory)
		{
			await _service.UpdateProductModifierAsync(id, productCategory);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ProductModifierResponseDto>> PostProductModifier(ProductModifierCreateDto productCategory)
		{
			return await _service.CreateProductModifierAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteProductModifier(Guid id)
		{
			await _service.DeleteProductModifierAsync(id);

			return NoContent();
		}
	}
}
