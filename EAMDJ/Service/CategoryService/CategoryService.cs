using EAMDJ.Dto;
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

		public async Task<ProductCategoryDto> CreateProductCategoryAsync(ProductCategoryDto productCategory)
		{
			ProductCategory created = await _repository.CreateProductCategoryAsync(ProductCategoryMapper.FromDto(productCategory));

			return ProductCategoryMapper.ToDto(created);


		}

		public async Task DeleteProductCategoryAsync(Guid id)
		{
			await _repository.DeleteProductCategoryAsync(id);
		}

		public async Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<ProductCategory> productCategories = await _repository.GetAllProductCategoriesByBusinessIdAsync(businessId);

			return productCategories.Select(ProductCategoryMapper.ToDto);
		}

		public async Task<ProductCategoryDto> GetProductCategoryAsync(Guid id)
		{
			ProductCategory productCategory = await _repository.GetProductCategoryAsync(id);

			return ProductCategoryMapper.ToDto(productCategory);
		}

		public async Task<ProductCategoryDto> UpdateProductCategoryAsync(Guid id, ProductCategoryDto productCategory)
		{
			ProductCategory updated = await _repository.UpdateProductCategoryAsync(id, ProductCategoryMapper.FromDto(productCategory));

			return ProductCategoryMapper.ToDto(updated);
		}
	}
}
