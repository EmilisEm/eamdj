using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMDJ.Model;

public class OrderItem {
    [Key] [ForeignKey("Product")] public Guid ProductId { get; init; }
    [Key] [ForeignKey("Order")] public Guid OrderId { get; init; }
    public uint Quantity { get; set; }

    // Not sure how to implement discounts.
    // An option would be to have each OrderItem point to a specific discount, then there would be a limit of one
    // discount per order item.
    // public Guid DiscountId { get; set; }

    // Another option would be to have an entity like OrderDiscounts, which would be able to unify Discounts and
    // DiscountCoupons.
    // Either way, I'm leaving DiscountCoupons for later.
}