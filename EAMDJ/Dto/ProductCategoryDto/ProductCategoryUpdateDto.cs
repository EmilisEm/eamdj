namespace EAMDJ.Dto.ProductCategoryDto
{
	public class ProductCategoryUpdateDto
	{
		public string? Name { get; set; }
		public ICollection<Guid>? TaxIds { get; set; }
	}
}
