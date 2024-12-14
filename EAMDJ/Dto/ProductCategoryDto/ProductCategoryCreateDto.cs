namespace EAMDJ.Dto.ProductCategoryDto
{
	public class ProductCategoryCreateDto
	{
		public string? Name { get; set; }
		public Guid BusinessId { get; set; }
		public ICollection<Guid>? TaxIds { get; set; }
	}
}
