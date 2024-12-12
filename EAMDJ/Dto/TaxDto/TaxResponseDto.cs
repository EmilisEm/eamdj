namespace EAMDJ.Dto.TaxDto
{
	public class TaxResponseDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; } = string.Empty;
		public decimal Percentage { get; init; } = decimal.Zero;
		public Guid BusinessId { get; init; }
	}
}
