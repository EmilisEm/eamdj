using EAMDJ.Dto.DiscountDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class DiscountMapper
	{
		public static DiscountResponseDto ToDto(Discount from)
		{
			return new DiscountResponseDto()
			{
				Id = from.Id,
				BusinessId = from.BusinessId,
				ProductId = from.ProductId,
				IsBusinessWide = from.IsBusinessWide,
				IsFlat = from.IsFlat,
				Amount = from.Amount,
				ExpirationDate = from.Expires,
			};
		}
		public static Discount FromDto(DiscountCreateDto from)
		{
			return new Discount()
			{
				Id = Guid.NewGuid(),
				BusinessId = from.BusinessId,
				ProductId = from.ProductId,
				IsBusinessWide = from.IsBusinessWide,
				IsFlat = from.IsFlat,
				Amount = from.Amount,
				Expires = from.ExpirationDate,
			};
		}
	}
}
