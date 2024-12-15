namespace EAMDJ.Dto.ServiceTimeDto
{
	public class ServiceTimeCreateDto
	{
		public Guid ServiceId { get; set; }
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
	}
}
