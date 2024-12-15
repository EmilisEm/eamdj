using EAMDJ.Dto.ProductCategoryDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.CategoryRepository;

namespace EAMDJ.Service.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;

		public CategoryService(ICategoryRepository repository)
		{
			_repository = repository;
		}

		public async Task<ProductCategoryResponseDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory)
		{
			ProductCategory created = await _repository.CreateProductCategoryAsync(ProductCategoryMapper.FromDto(productCategory));

			return ProductCategoryMapper.ToDto(created);


		}

		public async Task DeleteProductCategoryAsync(Guid id)
		{
			await _repository.DeleteProductCategoryAsync(id);
		}

		public async Task<IEnumerable<ProductCategoryResponseDto>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<ProductCategory> productCategories = await _repository.GetAllProductCategoriesByBusinessIdAsync(businessId);

			return productCategories.Select(ProductCategoryMapper.ToDto);
		}

		public async Task<ProductCategoryResponseDto> GetProductCategoryAsync(Guid id)
		{
			ProductCategory productCategory = await _repository.GetProductCategoryAsync(id);

			return ProductCategoryMapper.ToDto(productCategory);
		}

		public async Task<ProductCategoryResponseDto> UpdateProductCategoryAsync(Guid id, ProductCategoryUpdateDto productCategory)
		{
			ProductCategory original = await _repository.GetProductCategoryAsync(id);
			ProductCategory updated = await _repository.UpdateProductCategoryAsync(id, ProductCategoryMapper.FromDto(productCategory, id, original.BusinessId));

			return ProductCategoryMapper.ToDto(updated);
		}
	}
}
