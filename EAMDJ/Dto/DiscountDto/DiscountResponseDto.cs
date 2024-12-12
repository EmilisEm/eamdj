namespace EAMDJ.Dto.DiscountDto
{
	public class DiscountResponseDto
	{
		public Guid Id { get; init; }
		public decimal Percentage { get; set; } = decimal.Zero;
		public DateTime ExpirationDate { get; set; }
	}
}
