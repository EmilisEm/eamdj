using EAMDJ.Dto.OrderDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class OrderMapper
	{
		public static OrderResponseDto ToDto(Order from)
		{
			return new OrderResponseDto()
			{
				Id = from.Id,
				BusinessId = from.BusinessId,
				Status = from.Status,
				Discount = from.Discount == null ? null : DiscountMapper.ToDto(from.Discount),
				CreatedAt = from.CreatedAt,
				LastModifiedAt = from.LastModifiedAt,
				OrderItmes = from.OrderItems.Select(OrderItemMapper.ToDto).ToList(),
			};
		}
		public static Order FromDto(OrderCreateDto from)
		{
			return new Order()
			{
				Id = Guid.NewGuid(),
				BusinessId = from.BusinessId,
				CreatedAt = DateTime.UtcNow,
				LastModifiedAt = DateTime.UtcNow,
				Status = OrderStatus.Open,
			};
		}
		public static Order FromDto(OrderUpdateDto from, Order original)
		{
			original.LastModifiedAt = DateTime.UtcNow;
			original.PayedAmount = from.PaidAmount;
			original.DiscountId = from.DiscountCouponId;

			return original;
		}
	}
}
