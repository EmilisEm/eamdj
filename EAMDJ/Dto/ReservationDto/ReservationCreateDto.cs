namespace EAMDJ.Dto.ReservationDto
{
	public class ReservationCreateDto
	{
		public Guid ProductId { get; set; }
		public Guid ServiceTimeId { get; set; }
		public Guid EmployeeId { get; set; }
	}
}
