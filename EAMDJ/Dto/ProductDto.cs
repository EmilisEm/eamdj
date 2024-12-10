namespace EAMDJ.Dto
{
	public class ProductDto
	{
		public Guid Id { get; init; }
		public decimal Price { get; set; }
		public string Name { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
