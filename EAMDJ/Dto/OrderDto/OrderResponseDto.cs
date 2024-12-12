using EAMDJ.Model;

namespace EAMDJ.Dto.OrderDto
{
	public class OrderResponseDto
	{
		public Guid Id { get; init; }
		public decimal Price { get; init; }
		public decimal PaidAmount { get; init; }
		public Guid BusinessId { get; init; }
		public Guid DiscountCouponId { get; init; }
		public OrderStatus Status { get; init; }
		public DateTime CreatedAt { get; init; }
		public DateTime LastModifiedAt { get; init; }
	}
}
