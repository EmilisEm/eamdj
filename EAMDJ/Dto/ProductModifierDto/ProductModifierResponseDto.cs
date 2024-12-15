namespace EAMDJ.Dto.ProductModifierDto
{
	public class ProductModifierResponseDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; } = string.Empty;
		public decimal Price { get; init; } = decimal.Zero;
		public Guid ProductId { get; init; }
	}
}
