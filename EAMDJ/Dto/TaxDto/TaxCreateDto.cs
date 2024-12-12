namespace EAMDJ.Dto.TaxDto
{
	public class TaxCreateDto
	{
		public string Name { get; init; } = string.Empty;
		public decimal Percentage { get; init; } = decimal.Zero;
		public Guid CategoryId { get; init; }
	}
}
