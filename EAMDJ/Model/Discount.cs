namespace EAMDJ.Model;

public record Discount
{
	public Guid Id { get; init; }

	// Id of product which this discount affects.
	// Could be a good idea to allow discounts to point at ProductCategories as well.
	public Guid? ProductId { get; init; }
	public virtual Product Product { get; init; } = null!;
	public Guid BusinessId { get; init; }
	public virtual Business? Business { get; init; }
	public virtual List<Order> Orders { get; init; } = [];

	// Discount amount (Percentage or flat value)
	public decimal Amount { get; set; }

	// Flag which shows whether discount amount is percentage or flat value 
	public bool IsFlat { get; set; }
	public bool IsBusinessWide { get; set; }

	// Expiration date of this discount.
	public DateTime Expires { get; set; }
}