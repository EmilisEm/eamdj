namespace EAMDJ.Dto.DiscountDto
{
	public class DiscountCreateDto
	{
		public decimal Percentage { get; init; } = decimal.Zero;
		public DateTime ExpirationDate { get; init; }
	}
}
