using EAMDJ.Dto.ProductModifierDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.ProductModifierRepository;

namespace EAMDJ.Service.ProductModifierService
{
	public class ProductModifierService : IProductModifierService
	{
		private readonly IProductModifierRepository _repository;

		public ProductModifierService(IProductModifierRepository repository)
		{
			_repository = repository;
		}

		public async Task<ProductModifierResponseDto> CreateProductModifierAsync(ProductModifierCreateDto product)
		{
			ProductModifier created = await _repository.CreateProductModifierAsync(ProductModifierMapper.FromDto(product));

			return ProductModifierMapper.ToDto(created);


		}

		public async Task DeleteProductModifierAsync(Guid id)
		{
			await _repository.DeleteProductModifierAsync(id);
		}

		public async Task<IEnumerable<ProductModifierResponseDto>> GetAllProductModifiersByProductIdAsync(Guid productCategoryId)
		{
			IEnumerable<ProductModifier> products = await _repository.GetAllProductModifiersByProductIdAsync(productCategoryId);

			return products.Select(ProductModifierMapper.ToDto);
		}

		public async Task<ProductModifierResponseDto> GetProductModifierAsync(Guid id)
		{
			ProductModifier product = await _repository.GetProductModifierAsync(id);

			return ProductModifierMapper.ToDto(product);
		}

		public async Task<ProductModifierResponseDto> UpdateProductModifierAsync(Guid id, ProductModifierUpdateDto product)
		{
			ProductModifier original = await _repository.GetProductModifierAsync(id);

			ProductModifier updated = await _repository.UpdateProductModifierAsync(id, ProductModifierMapper.FromDto(product, original.Id, original.ProductId));

			return ProductModifierMapper.ToDto(updated);
		}
	}
}
