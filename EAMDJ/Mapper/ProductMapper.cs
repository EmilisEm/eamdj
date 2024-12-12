using EAMDJ.Dto.ProductDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductMapper
	{
		public static ProductResponseDto ToDto(Product from)
		{
			return new ProductResponseDto()
			{
				Id = from.Id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
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
			};
		}
		public static Product FromDto(ProductUpdateDto from, Guid id)
		{
			return new Product()
			{
				Id = id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
			};
		}
	}
}
