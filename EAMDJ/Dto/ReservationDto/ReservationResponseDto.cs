using EAMDJ.Dto.ServiceTimeDto;

namespace EAMDJ.Dto.ReservationDto
{
	public class ReservationResponseDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public Guid EmployeeId { get; set; }
		public ServiceTimeResponseDto ServiceTime { get; set; } = null!;
		public DateTime Created { get; set; }
	}
}
