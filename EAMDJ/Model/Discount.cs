using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public record Discount {
    [Key] public Guid Id { get; init; }

    // Id of product which this discount affects.
    // Could be a good idea to allow discounts to point at ProductCategories as well.
    [ForeignKey("Product")] public Guid ProductId { get; init; }

    // Percentage discount field (ex. 50% off on lunch menu).
    public decimal? Percentage { get; set; }

    // Flat discount field (ex. 2 Eur off on men's haircut).
    public decimal? Flat { get; set; }

    // Another idea would be to have a single field, with a flag that shows whether it's a flat discount or a percentage
    // discount.
    // public decimal Amount { get; set; }
    // public bool IsFlat { get; set; }

    // Expiration date of this discount.
    public DateTime Expires { get; set; }
}