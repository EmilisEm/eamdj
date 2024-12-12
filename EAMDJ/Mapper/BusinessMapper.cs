using EAMDJ.Dto.BusinessDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class BusinessMapper
	{
		public static BusinessResponseDto ToDto(Business from)
		{
			return new BusinessResponseDto()
			{
				Id = from.Id,
				Address = from.Address,
				Name = from.Name
			};
		}
		public static Business FromDto(BusinessCreateDto from)
		{
			return new Business()
			{
				Id = Guid.NewGuid(),
				Name = from.Name,
			};
		}
		public static Business FromDto(BusinessUpdateDto from, Guid id)
		{
			return new Business()
			{
				Id = id,
				Address = from.Address,
				Name = from.Name,
			};
		}

	}
}
