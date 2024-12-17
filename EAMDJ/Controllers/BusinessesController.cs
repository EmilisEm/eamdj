using EAMDJ.Dto.BusinessDto;
using EAMDJ.Service.BusinessService.BusinessService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/business")]
	[ApiController]
	public class BusinessesController : ControllerBase
	{
		private readonly IBusinessService _service;
		public BusinessesController(IBusinessService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BusinessResponseDto>>> GetBusiness(
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20)
		{
			if (page < 1 || pageSize < 1)
			{
				return BadRequest("Page and pageSize must be greater than 0.");
			}

			return Ok(await _service.GetAllBusinessAsync(page, pageSize));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BusinessResponseDto>> GetBusiness(Guid id)
		{
			return Ok(await _service.GetBusinessAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutBusiness(Guid id, BusinessUpdateDto business)
		{
			await _service.UpdateBusinessAsync(id, business);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<BusinessResponseDto>> PostBusiness(BusinessCreateDto business)
		{
			return await _service.CreateBusinessAsync(business);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBusiness(Guid id)
		{
			await _service.DeleteBusinessAsync(id);

			return NoContent();
		}
	}
}
