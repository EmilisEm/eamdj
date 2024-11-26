namespace EAMDJ.Model;

public class OrderItem
{
	public Guid Id { get; set; }
	public Guid ProductId { get; init; }
	public virtual Product Product { get; init; } = null!;
	public Guid OrderId { get; init; }
	public virtual Order Order { get; init; } = null!;
	public uint Quantity { get; set; }

	// Not sure how to implement discounts.
	// An option would be to have each OrderItem point to a specific discount, then there would be a limit of one
	// discount per order item.
	// public Guid DiscountId { get; set; }

	// Another option would be to have an entity like OrderDiscounts, which would be able to unify Discounts and
	// DiscountCoupons.
	// Either way, I'm leaving DiscountCoupons for later.
}