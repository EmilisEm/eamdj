using EAMDJ.Dto.ProductCategoryDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.CategoryRepository;
using EAMDJ.Repository.TaxRepository;

namespace EAMDJ.Service.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly ITaxRepository _taxRepository;

		public CategoryService(ICategoryRepository repository, ITaxRepository taxRepository)
		{
			_repository = repository;
			_taxRepository = taxRepository;
		}

		public async Task<ProductCategoryResponseDto> CreateProductCategoryAsync(ProductCategoryCreateDto productCategory)
		{
			var mapped = ProductCategoryMapper.FromDto(productCategory);
			mapped.Taxes = await _taxRepository.GetAllByIdsAsync(productCategory.TaxIds);

			ProductCategory created = await _repository.CreateProductCategoryAsync(mapped);

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
			original.Taxes = await _taxRepository.GetAllByIdsAsync(productCategory.TaxIds);

			ProductCategory updated = await _repository.UpdateProductCategoryAsync(id, ProductCategoryMapper.FromDto(productCategory, original));

			return ProductCategoryMapper.ToDto(updated);
		}
	}
}
