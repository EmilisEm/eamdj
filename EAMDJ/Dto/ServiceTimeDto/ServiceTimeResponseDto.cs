namespace EAMDJ.Dto.ServiceTimeDto
{
	public class ServiceTimeResponseDto
	{
		public Guid Id { get; set; }
		public Guid ServiceId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
