namespace EAMDJ.Model;

public record Product
{
	public Guid Id { get; init; }
	public decimal Price { get; set; }
	public string Name { get; set; } = string.Empty;

	// Id of the product category to which this product belongs to.
	// Might be a good idea to add a string representation of this later, so a UI doesn't have to also fetch category
	// names when getting the orders.
	public Guid CategoryId { get; set; }
	public virtual ProductCategory Category { get; set; } = null!;

	// We decided to implement modifiers later.
	// Keeping below comments for later.

	// Might be a good idea to merge modifiers and products. Could simplify price and tax calculations.
	// In that case it should have a flag denoting whether or not it's a modifier, or something similar.
	// public bool IsModifier { get; set; }
	// Could either have nullable lists for possible modifiers/products that it can be a modifier for.
	// Note that these lists would be entirely optional; you could use the Product entity without necessarily having
	// to fetch the entire list.
	// public List<Product>? CanModifyProducts { get; set; }
	// public List<Product>? PossibleModifiers { get; set; }

	// Description field from Service entity.
	// I think it would be a good idea to merge Product and Service into a single object, since they have a lot of
	// shared fields and shared behaviour.
	public string Description { get; set; } = string.Empty;
	public virtual ICollection<ProductModifier> ProductModifiers { get; set; } = new List<ProductModifier>();
	public virtual IEnumerable<Discount> Discounts { get; set; } = new List<Discount>();
}