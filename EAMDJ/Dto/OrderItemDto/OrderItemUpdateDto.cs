namespace EAMDJ.Dto.OrderItemDto
{
	public class OrderItemUpdateDto
	{
		public Guid ProductId { get; init; }
		public uint Quantity { get; set; }
		public IEnumerable<Guid>? ModifierIds { get; set; }
	}
}
