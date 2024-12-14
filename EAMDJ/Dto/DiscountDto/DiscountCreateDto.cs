namespace EAMDJ.Dto.DiscountDto
{
	public class DiscountCreateDto
	{
		public decimal Percentage { get; init; } = decimal.Zero;
		public DateTime ExpirationDate { get; init; }
		public Guid BusinessId { get; init; }
		public Guid ProductId { get; init; }
		public bool IsBusinessWide { get; init; }
		public bool IsFlat { get; init; }
		public decimal Amount { get; init; }
	}
}
