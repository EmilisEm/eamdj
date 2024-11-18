namespace EAMDJ.Model;

public record ProductCategory {
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public Guid BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    // Could be a good idea to add a ParentCategory field or something similar later.
    // Would allow more granularity with product categories for the end user.
    // 'Citrus fruit' is a subset of 'Fruit' which is a subset of 'Whole foods' etc. 
}