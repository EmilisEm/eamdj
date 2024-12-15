using EAMDJ.Dto.ProductDto;

namespace EAMDJ.Service.ProductService
{
	public interface IProductService
	{
		Task<ProductResponseDto> GetProductAsync(Guid id);
		Task<IEnumerable<ProductResponseDto>> GetAllProductsByProductCategoryIdAsync(Guid productCategoryId);
		Task<ProductResponseDto> UpdateProductAsync(Guid id, ProductUpdateDto product);
		Task DeleteProductAsync(Guid id);
		Task<ProductResponseDto> CreateProductAsync(ProductCreateDto product);
	}
}
