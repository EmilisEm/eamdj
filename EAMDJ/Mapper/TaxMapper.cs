using EAMDJ.Dto.TaxDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class TaxMapper
	{
		public static TaxResponseDto ToDto(Tax from)
		{
			return new TaxResponseDto()
			{
				Id = from.Id,
				BusinessId = from.BusinessId,
			};
		}
		public static Tax FromDto(TaxCreateDto from)
		{
			return new Tax()
			{
				Id = Guid.NewGuid(),
				BusinessId = from.BusinessId,
				Name = from.Name,
				Percentage = from.Percentage,
			};
		}
		public static Tax FromDto(TaxUpdateDto from, Guid id, Guid businessId)
		{
			return new Tax()
			{
				Id = id,
				BusinessId = businessId,
				Name = from.Name,
				Percentage = from.Percentage,
			};
		}
	}
}
