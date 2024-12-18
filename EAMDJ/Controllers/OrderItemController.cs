using EAMDJ.Dto.OrderItemDto;
using EAMDJ.Service.OrderItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/order-item")]
	[ApiController]
	[Authorize]
	public class OrderItemController : ControllerBase
	{
		private readonly IOrderItemService _service;
		public OrderItemController(IOrderItemService service)
		{
			_service = service;
		}

		[HttpGet("by-order/{id}")]
		public async Task<ActionResult<IEnumerable<OrderItemResponseDto>>> GetOrderItemsByOrderId(Guid id)
		{
			return Ok(await _service.GetAllOrderItemsByOrderIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderItemResponseDto>> GetOrderItem(Guid id)
		{
			return Ok(await _service.GetOrderItemAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrderItem(Guid id, OrderItemUpdateDto orderItem)
		{
			await _service.UpdateOrderItemAsync(id, orderItem);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<OrderItemResponseDto>> PostOrderItem(OrderItemCreateDto orderItem)
		{
			return await _service.CreateOrderItemAsync(orderItem);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteOrderItem(Guid id)
		{
			await _service.DeleteOrderItemAsync(id);

			return NoContent();
		}
	}
}
