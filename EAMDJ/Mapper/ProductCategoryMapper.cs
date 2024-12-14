using EAMDJ.Dto.ProductCategoryDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class ProductCategoryMapper
	{
		public static ProductCategoryResponseDto ToDto(ProductCategory from)
		{
			if (from.Taxes == null)
			{
				throw new ArgumentException("No taxes passed to product cateogry");
			}
			return new ProductCategoryResponseDto()
			{
				Id = from.Id,
				Name = from.Name,
				BusinessId = from.BusinessId,
				Taxes = from.Taxes.Select(TaxMapper.ToDto)
			};
		}
		public static ProductCategory FromDto(ProductCategoryCreateDto from)
		{
			return new ProductCategory()
			{
				Id = Guid.NewGuid(),
				Name = from.Name,
				BusinessId = from.BusinessId,
			};
		}
		public static ProductCategory FromDto(ProductCategoryUpdateDto from, Guid id, Guid businessId)
		{
			return new ProductCategory()
			{
				Id = id,
				Name = from.Name,
				BusinessId = businessId,
			};
		}
	}
}
