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
				ProductModifiers = from.ProductModifiers.Select(ProductModifierMapper.ToDto),
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
				ProductModifiers = new List<ProductModifier>()
			};
		}
		public static OrderItem FromDto(OrderItemUpdateDto from, OrderItem original)
		{
			original.ProductId = from.ProductId;
			original.Quantity = from.Quantity;

			return original;
		}
	}
}
