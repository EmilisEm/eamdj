using EAMDJ.Dto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.ProductRepository;

namespace EAMDJ.Service.ProductService
{
	public class ProductService: IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public async Task<ProductDto> CreateProductAsync(ProductDto product)
		{
			Product created = await _repository.CreateProductAsync(ProductMapper.FromDto(product));

			return ProductMapper.ToDto(created);


		}

		public async Task DeleteProductAsync(Guid id)
		{
			await _repository.DeleteProductAsync(id);
		}

		public async Task<IEnumerable<ProductDto>> GetAllProductsByProductCategoryIdAsync(Guid productCategoryId)
		{
			IEnumerable<Product> products = await _repository.GetAllProductsByProductCategoryIdAsync(productCategoryId);

			return products.Select(ProductMapper.ToDto);
		}

		public async Task<ProductDto> GetProductAsync(Guid id)
		{
			Product product = await _repository.GetProductAsync(id);

			return ProductMapper.ToDto(product);
		}

		public async Task<ProductDto> UpdateProductAsync(Guid id, ProductDto product)
		{
			Product updated = await _repository.UpdateProductAsync(id, ProductMapper.FromDto(product));

			return ProductMapper.ToDto(updated);
		}
	}
}
