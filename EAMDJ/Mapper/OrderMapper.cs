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
		public static Order FromDto(OrderUpdateDto from, Guid id, Guid businessId, OrderStatus status, DateTime created)
		{
			Console.WriteLine(from.PaidAmount);
			return new Order()
			{
				Id = id,
				PayedAmount = from.PaidAmount,
				BusinessId = businessId,
				Status = status,
				CreatedAt = created,
				LastModifiedAt = DateTime.UtcNow,
			};
		}
	}
}
