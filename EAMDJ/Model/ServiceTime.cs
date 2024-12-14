namespace EAMDJ.Model
{
	public class ServiceTime
	{
		public Guid Id { get; set; }
		public Guid ServiceId { get; set; }
		public virtual Product? Product { get; set; }
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
	}
}
