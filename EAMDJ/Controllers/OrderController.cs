using EAMDJ.Dto.OrderDto;
using EAMDJ.Model;
using EAMDJ.Service.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/order")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _service;
		public OrderController(IOrderService service)
		{
			_service = service;
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrdersByBusinessId(
			Guid id,
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20)
		{
			if (page < 1 || pageSize < 1)
			{
				return BadRequest("Page and pageSize must be greater than 0.");
			}

			var paginatedOrders = await _service.GetAllOrdersByBusinessIdAsync(id, page, pageSize);

			return Ok(paginatedOrders);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<OrderResponseDto>> GetOrder(Guid id)
		{
			return Ok(await _service.GetOrderAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(Guid id, OrderUpdateDto order)
		{
			await _service.UpdateOrderAsync(id, order);
			return NoContent();
		}

		[HttpPut("{id}/status")]
		public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] OrderUpdateStatusDto updateDto)
		{
			if (!Enum.IsDefined(typeof(OrderStatus), updateDto.NewStatus))
			{
				return BadRequest("Invalid OrderStatus value.");
			}

			return Ok(await _service.UpdateOrderStatusAsync(id, updateDto.NewStatus));
		}

		[HttpPost]
		public async Task<ActionResult<OrderResponseDto>> PostOrder(OrderCreateDto order)
		{
			return await _service.CreateOrderAsync(order);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteOrder(Guid id)
		{
			await _service.DeleteOrderAsync(id);

			return NoContent();
		}
	}
}
