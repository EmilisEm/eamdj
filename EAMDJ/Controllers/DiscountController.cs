using EAMDJ.Dto.DiscountDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.DiscountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/discount")]
	[ApiController]
	[Authorize]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _service;
		private readonly IAuthService _authService;
		public DiscountController(IDiscountService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-product/{id}")]
		public async Task<ActionResult<IEnumerable<DiscountResponseDto>>> GetDiscountsByProductId(Guid id)
		{
			var discounts = await _service.GetAllDiscountsByProductIdAsync(id);
			if (discounts.FirstOrDefault() != default && !_authService.AuthorizeForBusiness(discounts.First().BusinessId))
			{
				return Forbid();
			}

			return Ok(discounts);
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<DiscountResponseDto>>> GetDiscountsByBusinessId(Guid id)
		{
			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}

			return Ok(await _service.GetAllDiscountsByBusinessIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DiscountResponseDto>> GetDiscount(Guid id)
		{
			var discount = await _service.GetDiscountAsync(id);
			if (!_authService.AuthorizeForBusiness(discount.BusinessId))
			{
				return Forbid();
			}

			return Ok(discount);
		}

		[HttpPost]
		public async Task<ActionResult<DiscountResponseDto>> PostDiscount(DiscountCreateDto productCategory)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(productCategory.BusinessId))
			{
				return Forbid();
			}

			return await _service.CreateDiscountAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteDiscount(Guid id)
		{
			var discount = await _service.GetDiscountAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(discount.BusinessId))
			{
				return Forbid();
			}

			await _service.DeleteDiscountAsync(id);

			return NoContent();
		}
	}
}
