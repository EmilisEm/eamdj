using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public record Tax {
    [Key] public Guid Id { get; init; }
    public string? Name { get; set; }
    public decimal Percentage { get; set; }

    // Data model does not specify, but implies a ProductCategoryId field.
    [ForeignKey("ProductCategory")] public Guid ProductCategoryId { get; set; }
}