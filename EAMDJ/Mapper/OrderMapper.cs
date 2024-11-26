using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class OrderMapper
	{
		public static OrderDto ToDto(Order from)
		{
			return new OrderDto()
			{
				Id = from.Id,
				BusinessId = from.BusinessId,
				Status = from.Status,
				CreatedAt = from.CreatedAt,
				LastModifiedAt = from.LastModifiedAt,
			};
		}
		public static Order FromDto(OrderDto from)
		{
			return new Order()
			{
				Id = from.Id,
				BusinessId = from.BusinessId,
				Status = from.Status,
				CreatedAt = from.CreatedAt,
				LastModifiedAt = from.LastModifiedAt,
			};
		}
	}
}
