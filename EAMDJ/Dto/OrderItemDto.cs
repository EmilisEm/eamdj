namespace EAMDJ.Dto
{
	public class OrderItemDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; init; }
		public Guid OrderId { get; init; }
		public uint Quantity { get; set; }
	}
}
