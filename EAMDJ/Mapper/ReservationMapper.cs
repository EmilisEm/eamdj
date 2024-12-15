using EAMDJ.Dto.ReservationDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ReservationMapper
	{
		public static ReservationResponseDto ToDto(Reservation from)
		{
			if (from.ServiceTime == null) throw new ArgumentException("Failed to convert ServiceTime to DTO");
			return new ReservationResponseDto()
			{
				Id = from.Id,
				ProductId = from.ProductId,
				EmployeeId = from.EmployeeId,
				ServiceTime = ServiceTimeMapper.ToDto(from.ServiceTime),
				Created = from.Created,
			};
		}
		public static Reservation FromDto(ReservationCreateDto from)
		{
			return new Reservation()
			{
				Id = Guid.NewGuid(),
				ProductId = from.ProductId,
				EmployeeId = from.EmployeeId,
				ServiceTimeId = from.ServiceTimeId,
				Created = DateTime.UtcNow,
				Updated = DateTime.UtcNow,
			};
		}
		public static Reservation FromDto(ReservationUpdateDto from, Reservation original)
		{
			return new Reservation()
			{
				Id = original.Id,
				ProductId = original.ProductId,
				EmployeeId = from.EmployeeId,
				ServiceTimeId = original.ServiceTimeId,
				Created = original.Created,
				Updated = DateTime.UtcNow,
			};
		}
	}
}
