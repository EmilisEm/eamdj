using EAMDJ.Dto;

namespace EAMDJ.Service.CategoryService
{
	public interface ICategoryService
	{
		Task<ProductCategoryDto> GetProductCategoryAsync(Guid id);
		Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId);
		Task<ProductCategoryDto> UpdateProductCategoryAsync(Guid id, ProductCategoryDto productCategory);
		Task DeleteProductCategoryAsync(Guid id);
		Task<ProductCategoryDto> CreateProductCategoryAsync(ProductCategoryDto productCategory);
	}
}
