namespace EAMDJ.Model;

public class OrderItem {
    public Guid ProductId { get; init; }
    public Guid OrderId { get; init; }
    public uint Quantity { get; set; }
}