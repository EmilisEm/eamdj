namespace EAMDJ.Dto.OrderDto
{
	public class OrderUpdateDto
	{
		public decimal PaidAmount { get; init; }
		public Guid DiscountCouponId { get; init; }
	}
}
