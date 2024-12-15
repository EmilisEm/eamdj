using EAMDJ.Dto.DiscountDto;
using EAMDJ.Dto.ProductModifierDto;

namespace EAMDJ.Dto.ProductDto
{
	public class ProductResponseDto
	{
		public Guid Id { get; init; }
		public decimal Price { get; set; }
		public string Name { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
		public string Description { get; set; } = string.Empty;
		public IEnumerable<ProductModifierResponseDto> Modifiers { get; set; } = [];
		public IEnumerable<DiscountResponseDto> Discounts { get; set; } = [];
	}
}
