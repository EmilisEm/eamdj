namespace EAMDJ.Dto.TaxDto
{
	public class TaxUpdateDto
	{
		public string Name { get; init; } = string.Empty;
		public decimal Percentage { get; init; } = decimal.Zero;
	}
}
