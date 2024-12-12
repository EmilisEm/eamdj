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
			};
		}
		public static Order FromDto(OrderCreateDto from)
		{
			return new Order()
			{
				Id = Guid.NewGuid(),
				BusinessId = from.BusinessId,
			};
		}
		public static Order FromDto(OrderUpdateDto from, Guid id, Guid businessId, OrderStatus status, DateTime created)
		{
			return new Order()
			{
				Id = id,
				PayedAmount = from.PaidAmount,
				BusinessId = businessId,
				Status = status,
				CreatedAt = created,
				LastModifiedAt = DateTime.Now,
			};
		}
	}
}
