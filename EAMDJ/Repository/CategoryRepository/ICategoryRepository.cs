using EAMDJ.Model;

namespace EAMDJ.Repository.CategoryRepository
{
	public interface ICategoryRepository
	{		
		Task<ProductCategory> GetProductCategoryAsync(Guid id);
		Task<IEnumerable<ProductCategory>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId);
		Task<ProductCategory> UpdateProductCategoryAsync(Guid id, ProductCategory productCategory);
		Task DeleteProductCategoryAsync(Guid id);
		Task<ProductCategory> CreateProductCategoryAsync(ProductCategory productCategory);


	}
}
