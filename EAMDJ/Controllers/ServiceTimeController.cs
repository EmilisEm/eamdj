using EAMDJ.Dto.ServiceTimeDto;
using EAMDJ.Service.ServiceTimeService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/service-time")]
	[ApiController]
	public class ServiceTimeController : ControllerBase
	{
		private readonly IServiceTimeService _service;
		public ServiceTimeController(IServiceTimeService service)
		{
			_service = service;
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
			await _service.UpdateServiceTimeAsync(id, productCategory);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ServiceTimeResponseDto>> PostServiceTime(ServiceTimeCreateDto productCategory)
		{
			return await _service.CreateServiceTimeAsync(productCategory);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteServiceTime(Guid id)
		{
			await _service.DeleteServiceTimeAsync(id);

			return NoContent();
		}
	}
}
