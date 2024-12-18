using EAMDJ.Dto.OrderDto;
using EAMDJ.Dto.ReservationDto;
using EAMDJ.Model;
using EAMDJ.Service.ReservationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/reservation")]
	[ApiController]
	[Authorize]
	public class ReservationController : ControllerBase
	{
		private readonly IReservationService _service;
		public ReservationController(IReservationService service)
		{
			_service = service;
		}

		[HttpGet("by-product/{id}")]
		public async Task<ActionResult<IEnumerable<ReservationResponseDto>>> GetReservationsByBusinessId(Guid id)
		{
			return Ok(await _service.GetAllReservationsByProductIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ReservationResponseDto>> GetReservation(Guid id)
		{
			return Ok(await _service.GetReservationAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutReservation(Guid id, ReservationUpdateDto reservation)
		{
			await _service.UpdateReservationAsync(id, reservation);
			return NoContent();
		}
		[HttpPut("{id}/status")]
		public async Task<IActionResult> UpdateReservationStatus(Guid id, [FromBody] ReservationUpdateStatusDto updateDto)
		{
			if (!Enum.IsDefined(typeof(ReservationStatus), updateDto.NewStatus))
			{
				return BadRequest("Invalid ReservationStatus value.");
			}

			return Ok(await _service.UpdateReservationStatusAsync(id, updateDto.NewStatus));
		}
		[HttpPost]
		public async Task<ActionResult<ReservationResponseDto>> PostReservation(ReservationCreateDto reservation)
		{
			return await _service.CreateReservationAsync(reservation);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteReservation(Guid id)
		{
			await _service.DeleteReservationAsync(id);

			return NoContent();
		}
	}
}
