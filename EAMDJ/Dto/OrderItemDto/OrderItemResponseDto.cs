namespace EAMDJ.Dto.OrderItemDto
{
	public class OrderItemResponseDto
	{
		public Guid Id { get; init; }
		public Guid ProductId { get; init; }
		public Guid OrderId { get; init; }
		public uint Quantity { get; init; }
		public decimal BasePrice { get; init; }
		public decimal Tax { get; init; }
	}
}
