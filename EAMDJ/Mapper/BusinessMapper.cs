using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class BusinessMapper
	{
		public static BusinessDto ToDto(Business from)
		{
			return new BusinessDto()
			{
				Id = from.Id,
				Address = from.Address,
				Name = from.Name
			};
		}
		public static Business FromDto(BusinessDto from)
		{
			return new Business()
			{
				Id = from.Id,
				Address = from.Address,
				Name = from.Name
			};
		}

	}
}
