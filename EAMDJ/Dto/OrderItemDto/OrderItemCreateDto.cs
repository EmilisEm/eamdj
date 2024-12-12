namespace EAMDJ.Dto.OrderItemDto
{
	public class OrderItemCreateDto
	{
		public Guid ProductId { get; init; }
		public Guid OrderId { get; init; }
		public uint Quantity { get; set; }
	}
}
