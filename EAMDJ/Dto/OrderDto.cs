using EAMDJ.Model;

namespace EAMDJ.Dto
{
	public class OrderDto
	{
		public Guid Id { get; init; }
		public Guid BusinessId { get; init; }
		public OrderStatus Status { get; init; }
		public DateTime CreatedAt { get; init; }
		public DateTime LastModifiedAt { get; set; }
	}
}
