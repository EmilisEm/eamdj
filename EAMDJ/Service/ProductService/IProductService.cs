using EAMDJ.Dto;

namespace EAMDJ.Service.ProductService
{
	public interface IProductService
	{
		Task<ProductDto> GetProductAsync(Guid id);
		Task<IEnumerable<ProductDto>> GetAllProductsByProductCategoryIdAsync(Guid productCategoryId);
		Task<ProductDto> UpdateProductAsync(Guid id, ProductDto product);
		Task DeleteProductAsync(Guid id);
		Task<ProductDto> CreateProductAsync(ProductDto product);
	}
}
