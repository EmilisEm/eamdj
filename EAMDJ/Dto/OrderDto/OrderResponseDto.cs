﻿using EAMDJ.Dto.DiscountDto;
using EAMDJ.Dto.OrderItemDto;
using EAMDJ.Model;

namespace EAMDJ.Dto.OrderDto
{
	public class OrderResponseDto
	{
		public Guid Id { get; init; }
		public decimal TotalPrice { get; set; }
		public decimal Tax { get; set; }
		public decimal PaidAmount { get; init; }
		public Guid BusinessId { get; init; }
		public DiscountResponseDto? Discount { get; init; }
		public OrderStatus Status { get; init; }
		public DateTime CreatedAt { get; init; }
		public DateTime LastModifiedAt { get; init; }
		public IEnumerable<OrderItemResponseDto> OrderItmes { get; set; } = new List<OrderItemResponseDto>();
	}
}
