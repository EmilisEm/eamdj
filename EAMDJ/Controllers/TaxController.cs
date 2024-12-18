using EAMDJ.Dto.TaxDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.TaxService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/tax")]
	[ApiController]
	[Authorize]
	public class TaxController : ControllerBase
	{
		private readonly ITaxService _service;
		private readonly IAuthService _authService;
		public TaxController(ITaxService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TaxResponseDto>> GetTax(Guid id)
		{
			return Ok(await _service.GetTaxAsync(id));
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<TaxResponseDto>>> GetTaxByBusiness(Guid id)
		{
			return Ok(await _service.GetTaxByBusinessAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTax(Guid id, TaxUpdateDto product)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			await _service.UpdateTaxAsync(id, product);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<TaxResponseDto>> PostTax(TaxCreateDto product)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			return await _service.CreateTaxAsync(product);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteTax(Guid id)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			await _service.DeleteTaxAsync(id);

			return NoContent();
		}

	}
}
