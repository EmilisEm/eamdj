using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductCategoryMapper
	{
		public static ProductCategoryDto ToDto(ProductCategory from)
		{
			return new ProductCategoryDto()
			{
				Id = from.Id,
				Name = from.Name,
				BusinessId = from.BusinessId,
			};
		}
		public static ProductCategory FromDto(ProductCategoryDto from)
		{
			return new ProductCategory()
			{
				Id = from.Id,
				Name = from.Name,
				BusinessId = from.BusinessId,
			};
		}
	}
}
