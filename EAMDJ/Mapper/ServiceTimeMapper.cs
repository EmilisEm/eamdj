using EAMDJ.Dto.ServiceTimeDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public class ServiceTimeMapper
	{
		public static ServiceTimeResponseDto ToDto(ServiceTime from)
		{
			return new ServiceTimeResponseDto()
			{
				Id = from.Id,
				ServiceId = from.ServiceId,
				Start = from.Start,
				End = from.End,
			};
		}
		public static ServiceTime FromDto(ServiceTimeCreateDto from)
		{
			return new ServiceTime()
			{
				Id = Guid.NewGuid(),
				ServiceId = from.ServiceId,
				Start = from.Start,
				End = from.End,
			};
		}
		public static ServiceTime FromDto(ServiceTimeUpdateDto from, Guid id, Guid serviceId)
		{
			return new ServiceTime()
			{
				Id = id,
				ServiceId = serviceId,
				Start = from.Start,
				End = from.End,
			};
		}
	}
}
