using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class OrderItemMapper
	{
		public static OrderItemDto ToDto(OrderItem from)
		{
			return new OrderItemDto()
			{
				Id = from.Id,
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
			};
		}
		public static OrderItem FromDto(OrderItemDto from)
		{
			return new OrderItem()
			{
				Id = from.Id,
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
			};
		}
	}
}
