using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductMapper
	{
		public static ProductDto ToDto(Product from)
		{
			return new ProductDto()
			{
				Id = from.Id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
			};
		}
		public static Product FromDto(ProductDto from)
		{
			return new Product()
			{
				Id = from.Id,
				Name = from.Name,
				Price = from.Price,
				CategoryId = from.CategoryId,
				Description = from.Description,
			};
		}
	}
}
