using EAMDJ.Dto.BusinessDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.BusinessService.BusinessService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/business")]
	[ApiController]
	[Authorize]
	public class BusinessesController : ControllerBase
	{
		private readonly IBusinessService _service;
		private readonly IAuthService _authService;
		public BusinessesController(IBusinessService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BusinessResponseDto>>> GetBusiness()
		{
			return Ok(await _service.GetAllBusinessAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BusinessResponseDto>> GetBusiness(Guid id)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}

			return Ok(await _service.GetBusinessAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutBusiness(Guid id, BusinessUpdateDto business)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}

			await _service.UpdateBusinessAsync(id, business);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<BusinessResponseDto>> PostBusiness(BusinessCreateDto business)
		{
			if (!_authService.AuthorizeToAdmin())
			{
				return Forbid();
			}

			return await _service.CreateBusinessAsync(business);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBusiness(Guid id)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}

			await _service.DeleteBusinessAsync(id);

			return NoContent();
		}
	}
}
