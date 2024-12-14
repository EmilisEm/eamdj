namespace EAMDJ.Model
{
	public class ServiceTime
	{
		public Guid Id { get; set; }
		public Guid ServiceId { get; set; }
		public virtual Product? Product { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
