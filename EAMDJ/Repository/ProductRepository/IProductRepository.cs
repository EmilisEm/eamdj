using EAMDJ.Model;

namespace EAMDJ.Repository.ProductRepository
{
	public interface IProductRepository
	{
		Task<Product> GetProductAsync(Guid id);
		Task<IEnumerable<Product>> GetAllProductsByProductCategoryIdAsync(Guid categoryId);
		Task<Product> UpdateProductAsync(Guid id, Product product);
		Task DeleteProductAsync(Guid id);
		Task<Product> CreateProductAsync(Product product);
	}
}
