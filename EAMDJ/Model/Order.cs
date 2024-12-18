namespace EAMDJ.Model;

public record Order
{
	public Guid Id { get; init; }

	// The data model specifies a customer id stored with every order.
	// I don't think this is a good idea, because:
	// - Customer may be unknown; Customer entity has lots of mandatory information like email, phone number, address.
	// - It would be inconvenient to get all of this information in a point-of-sale system.
	// - Confusion when splitting the bill; multiple customers payed but only one listed in order.
	// Guid CustomerId { get; set; }

	// Id pointing to which business this order belongs to.
	public Guid BusinessId { get; init; }
	public virtual Business Business { get; init; } = null!;
	public decimal PayedAmount { get; set; }
	public Guid? DiscountId { get; set; }
	public virtual Discount? Discount { get; set; }

	// Not sure if this should be added because it implies that only one discount coupon may be used on an order.
	// Guid? DiscountCouponId { get; set; }

	// Status of this order (whether it's open, closed, paid-for, etc.).
	// Merged into Order entity from OrderLog entity.
	public OrderStatus Status { get; set; }

	// Timestamps: Create using DateTime.UtcNow property.
	// Ex. `var timeStamp = DateTime.UtcNow;`.
	// Make sure it's UTC.
	public DateTime CreatedAt { get; init; }
	public DateTime LastModifiedAt { get; set; }
	public virtual IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}