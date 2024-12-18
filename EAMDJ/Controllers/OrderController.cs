using EAMDJ.Dto.OrderDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/order")]
	[ApiController]
	[Authorize]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _service;
		private readonly IAuthService _authService;
		public OrderController(IOrderService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrdersByBusinessId(
			Guid id,
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20)
		{
			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}

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
			var order = await _service.GetOrderAsync(id);
			if (!_authService.AuthorizeForBusiness(order.BusinessId))
			{
				return Forbid();
			}

			return Ok(order);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(Guid id, OrderUpdateDto order)
		{
			var original = await _service.GetOrderAsync(id);
			if (!_authService.AuthorizeForBusiness(original.BusinessId))
			{
				return Forbid();
			}

			await _service.UpdateOrderAsync(id, order);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<OrderResponseDto>> PostOrder(OrderCreateDto order)
		{
			if (!_authService.AuthorizeForBusiness(order.BusinessId))
			{
				return Forbid();
			}

			return await _service.CreateOrderAsync(order);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteOrder(Guid id)
		{
			var order = await _service.GetOrderAsync(id);
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			if (!_authService.AuthorizeForBusiness(order.BusinessId))
			{
				return Forbid();
			}

			await _service.DeleteOrderAsync(id);

			return NoContent();
		}

		[HttpPut("pay/{id}")]
		public async Task<ActionResult<OrderResponseDto>> PayOrder(Guid id, decimal sum)
		{
			return await _service.PaySumForOrder(id, sum);
		}
	}
}
