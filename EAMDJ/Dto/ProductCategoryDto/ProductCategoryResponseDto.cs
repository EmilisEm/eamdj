using EAMDJ.Dto.TaxDto;

namespace EAMDJ.Dto.ProductCategoryDto
{
	public class ProductCategoryResponseDto
	{
		public Guid Id { get; init; }
		public string? Name { get; set; }
		public Guid BusinessId { get; set; }
		public IEnumerable<TaxResponseDto>? Taxes { get; set; }
	}
}
