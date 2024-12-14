﻿using EAMDJ.Dto.OrderDto;
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
		public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrdersByBusinessId(Guid id)
		{
			return Ok(await _service.GetAllOrdersByBusinessIdAsync(id));
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