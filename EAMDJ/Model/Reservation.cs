namespace EAMDJ.Model
{
	public class Reservation
	{
		public Guid Id { get; set; }
		public Guid ServiceTimeId { get; set; }
		public virtual ServiceTime? ServiceTime { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product? Product { get; set; }
		public Guid EmployeeId { get; set; }
		public virtual User? Employee { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
