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
				Name = from.Name,
				Percentage = from.Percentage,
				BusinessId = from.BusinessId,
			};
		}
		public static Tax FromDto(TaxCreateDto from)
		{
			return new Tax()
			{
				Id = Guid.NewGuid(),
				Name = from.Name,
				Percentage = from.Percentage,
				BusinessId = from.BusinessId,
			};
		}
		public static Tax FromDto(TaxUpdateDto from, Tax original)
		{
			original.Name = from.Name;
			original.Percentage = from.Percentage;

			return original;
		}
	}
}
