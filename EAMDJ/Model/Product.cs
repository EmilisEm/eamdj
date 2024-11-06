namespace EAMDJ.Model;

public record Product {
    public Guid Id { get; init; }
    public decimal Price { get; set; }
    public string Name { get; set; }

    // Id of the product category to which this product belongs to.
    // Might be a good idea to add a string representation of this later, so a UI doesn't have to also fetch category
    // names when getting the orders.
    public Guid CategoryId { get; set; }
}