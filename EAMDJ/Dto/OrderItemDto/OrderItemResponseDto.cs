using EAMDJ.Dto.DiscountDto;
using EAMDJ.Dto.ProductModifierDto;

namespace EAMDJ.Dto.OrderItemDto
{
	public class OrderItemResponseDto
	{
		public Guid Id { get; init; }
		public Guid ProductId { get; init; }
		public Guid OrderId { get; init; }
		public uint Quantity { get; init; }
		public decimal BasePrice { get; init; }
		public decimal TaxPercent { get; init; }
		public DiscountResponseDto? AppliedDiscount { get; set; }
		public IEnumerable<ProductModifierResponseDto>? ProductModifiers { get; set; }
	}
}
