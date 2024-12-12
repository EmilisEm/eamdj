using EAMDJ.Dto.OrderItemDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class OrderItemMapper
	{
		public static OrderItemResponseDto ToDto(OrderItem from)
		{
			return new OrderItemResponseDto()
			{
				Id = from.Id,
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
			};
		}
		public static OrderItem FromDto(OrderItemCreateDto from)
		{
			return new OrderItem()
			{
				Id = Guid.NewGuid(),
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
			};
		}
		public static OrderItem FromDto(OrderItemUpdateDto from, Guid id, Guid orderId)
		{
			return new OrderItem()
			{
				Id = id,
				OrderId = orderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
			};
		}
	}
}
