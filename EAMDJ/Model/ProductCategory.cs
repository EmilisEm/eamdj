using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public record ProductCategory {
    [Key] public Guid Id { get; init; }
    public string? Name { get; set; }
    [ForeignKey("Business")] public Guid BusinessId { get; set; }

    // Could be a good idea to add a ParentCategory field or something similar later.
    // Would allow more granularity with product categories for the end user.
    // 'Citrus fruit' is a subset of 'Fruit' which is a subset of 'Whole foods' etc. 
}