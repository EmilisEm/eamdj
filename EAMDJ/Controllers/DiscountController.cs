using EAMDJ.Dto.DiscountDto;
using EAMDJ.Service.DiscountService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/discount")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _service;
		public DiscountController(IDiscountService service)
		{
			_service = service;
		}

		[HttpGet("by-product/{id}")]
		public async Task<ActionResult<IEnumerable<DiscountResponseDto>>> GetDiscountsByProductId(Guid id)
		{
			return Ok(await _service.GetAllDiscountsByProductIdAsync(id));
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<DiscountResponseDto>>> GetDiscountsByBusinessId(Guid id)
		{
			return Ok(await _service.GetAllDiscountsByBusinessIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DiscountResponseDto>> GetDiscount(Guid id)
		{
			return Ok(await _service.GetDiscountAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<DiscountResponseDto>> PostDiscount(DiscountCreateDto productCategory)
		{
			return await _service.CreateDiscountAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteDiscount(Guid id)
		{
			await _service.DeleteDiscountAsync(id);

			return NoContent();
		}
	}
}
