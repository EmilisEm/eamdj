namespace EAMDJ.Dto.ServiceTimeDto
{
	public class ServiceTimeCreateDto
	{
		public Guid ServiceId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
