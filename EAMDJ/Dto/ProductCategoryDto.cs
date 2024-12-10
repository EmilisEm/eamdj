namespace EAMDJ.Dto
{
	public class ProductCategoryDto
	{
		public Guid Id { get; init; }
		public string? Name { get; set; }
		public Guid BusinessId { get; set; }
	}
}
