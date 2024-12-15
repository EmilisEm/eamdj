namespace EAMDJ.Dto.ProductModifierDto
{
	public class ProductModifierCreateDto
	{
		public string Name { get; init; } = string.Empty;
		public decimal Price { get; init; } = decimal.Zero;
		public Guid ProductId { get; init; }
	}
}
