namespace EAMDJ.Dto.DiscountDto
{
	public class DiscountResponseDto
	{
		public Guid Id { get; init; }
		public decimal Amount { get; set; } = decimal.Zero;
		public DateTime ExpirationDate { get; set; }
		public Guid? ProductId { get; set; }
		public Guid BusinessId { get; set; }
		public bool IsBusinessWide { get; set; }
		public bool IsFlat { get; set; }
	}
}
