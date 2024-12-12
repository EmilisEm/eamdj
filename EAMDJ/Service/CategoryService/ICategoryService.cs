using EAMDJ.Dto.ProductCategoryDto;

namespace EAMDJ.Service.CategoryService
{
	public interface ICategoryService
	{
		Task<ProductCategoryResponseDto> GetProductCategoryAsync(Guid id);
		Task<IEnumerable<ProductCategoryResponseDto>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId);
		Task<ProductCategoryResponseDto> UpdateProductCategoryAsync(Guid id, ProductCategoryUpdateDto productCategory);
		Task DeleteProductCategoryAsync(Guid id);
		Task<ProductCategoryResponseDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory);
	}
}
