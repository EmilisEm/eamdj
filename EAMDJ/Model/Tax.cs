namespace EAMDJ.Model;

public record Tax {
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public decimal Percentage { get; set; }

    // Data model does not specify, but implies a ProductCategoryId field.
    public Guid ProductCategoryId { get; set; }
}