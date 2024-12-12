using EAMDJ.Dto.ProductModifierDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductModifierMapper
	{
		public static ProductModifierResponseDto ToDto(ProductModifier from)
		{
			return new ProductModifierResponseDto()
			{
				Id = from.Id,
				Name = from.Name,
				Price = from.Price,
				ProductId = from.ProductId,
			};
		}
		public static ProductModifier FromDto(ProductModifierCreateDto from)
		{
			return new ProductModifier()
			{
				Id = Guid.NewGuid(),
				Name = from.Name,
				Price = from.Price,
				ProductId = from.ProductId,
			};
		}
		public static ProductModifier FromDto(ProductModifierUpdateDto from, Guid id, Guid productId)
		{
			return new ProductModifier()
			{
				Id = id,
				Name = from.Name,
				Price = from.Price,
				ProductId = productId,
			};
		}
	}
}
