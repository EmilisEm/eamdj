namespace EAMDJ.Dto
{
	public class OrderItemDto
	{
    public Guid ProductId { get; init; }
    public Guid OrderId { get; init; }
    public virtual OrderDto Order { get; init; } = null!;
    public uint Quantity { get; set; }
	}
}
