using EAMDJ.Dto.ServiceTimeDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.ServiceTimeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/service-time")]
	[ApiController]
	[Authorize]
	public class ServiceTimeController : ControllerBase
	{
		private readonly IServiceTimeService _service;
		private readonly IAuthService _authService;
		public ServiceTimeController(IServiceTimeService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-product/{id}")]
		public async Task<ActionResult<IEnumerable<ServiceTimeResponseDto>>> GetServiceTimesByBusinessId(Guid id)
		{
			return Ok(await _service.GetAllServiceTimesByProductIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceTimeResponseDto>> GetServiceTime(Guid id)
		{
			return Ok(await _service.GetServiceTimeAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutServiceTime(Guid id, ServiceTimeUpdateDto productCategory)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			await _service.UpdateServiceTimeAsync(id, productCategory);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ServiceTimeResponseDto>> PostServiceTime(ServiceTimeCreateDto productCategory)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			return await _service.CreateServiceTimeAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteServiceTime(Guid id)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			await _service.DeleteServiceTimeAsync(id);

			return NoContent();
		}
	}
}
