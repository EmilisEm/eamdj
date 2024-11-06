namespace EAMDJ.Model;

public record Product {
    public Guid Id { get; init; }
    public decimal Price { get; set; }
    public string Name { get; set; }

    // Id of the product category to which this product belongs to.
    // Might be a good idea to add a string representation of this later, so a UI doesn't have to also fetch category
    // names when getting the orders.
    public Guid CategoryId { get; set; }

    // Might be a good idea to merge modifiers and products. Could simplify price and tax calculations.
    // In that case it should have a flag denoting whether or not it's a modifier, or something similar.
    // public bool IsModifier { get; set; }
    // Could either have nullable lists for possible modifiers/products that it can be a modifier for
    // public List<Product>? CanModifyProducts { get; set; }
    // public List<Product>? PossibleModifiers { get; set; }
}