namespace EAMDJ.Dto.ProductCategoryDto
{
	public class ProductCategoryUpdateDto
	{
		public string? Name { get; set; }
		public IEnumerable<Guid> TaxIds { get; set; } = [];
	}
}
