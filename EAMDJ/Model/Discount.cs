using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public record Discount {
    public Guid Id { get; init; }

    // Id of product which this discount affects.
    // Could be a good idea to allow discounts to point at ProductCategories as well.
    public Guid ProductId { get; init; }
    
    // Discount amount (Percentage or flat value)
    public decimal Amount { get; set; }
    
    // Flag which shows whether discount amount is percentage or flat value 
    public bool IsFlat { get; set; }

    // Expiration date of this discount.
    public DateTime Expires { get; set; }
}