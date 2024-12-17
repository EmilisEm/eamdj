using EAMDJ.Dto.ProductDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductMapper
	{
		public static ProductResponseDto ToDto(Product from)
		{
			if (from.ProductModifiers == null)
			{
				throw new ArgumentException("Failed to fetch product modifiers for product with ID " + from.Id);
			}
			if (from.Discounts == null)
			{
				throw new ArgumentException("Failed to fetch discounts for product with ID " + from.Id);
			}

			return new ProductResponseDto()
			{
				Id = from.Id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
				Modifiers = from.ProductModifiers.Select(ProductModifierMapper.ToDto),
				Discounts = from.Discounts.Select(DiscountMapper.ToDto),
			};
		}
		public static Product FromDto(ProductCreateDto from)
		{
			return new Product()
			{
				Id = Guid.NewGuid(),
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
				ProductModifiers = new List<ProductModifier>()
			};
		}
		public static Product FromDto(ProductUpdateDto from, Product original)
		{
			return new Product()
			{
				Id = original.Id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
				ProductModifiers = original.ProductModifiers
			};
		}
	}
}
