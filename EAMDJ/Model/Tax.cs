using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public record Tax {
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public decimal Percentage { get; set; }
    public Guid ProductCategoryId { get; set; }
}