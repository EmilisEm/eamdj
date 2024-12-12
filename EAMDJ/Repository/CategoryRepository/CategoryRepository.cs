using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.CategoryRepository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ServiceAppContext _context;

		public CategoryRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategory productCategory)
		{
			Guid id = Guid.NewGuid();

			// TODO: Validate order and product existence. Throw exception

			_context.ProductCategory.Add(productCategory);
			await _context.SaveChangesAsync();

			return productCategory;
		}

		public async Task DeleteProductCategoryAsync(Guid id)
		{
			var productCategory = await _context.ProductCategory.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.ProductCategory.Remove(productCategory);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesByBusinessIdAsync(Guid businessId)
		{
			return await _context.ProductCategory.Where(it => it.BusinessId.Equals(businessId)).ToListAsync();
		}

		public async Task<ProductCategory> GetProductCategoryAsync(Guid id)
		{
			var productCategory = await _context.ProductCategory.FindAsync(id);

			if (productCategory == null)
			{
				throw new ArgumentException("ProductCategory not found");
			}

			return productCategory;
		}

		public async Task<ProductCategory> UpdateProductCategoryAsync(Guid id, ProductCategory productCategory)
		{
			if (id != productCategory.Id)
			{
				throw new ArgumentException("ProductCategory not found");
			}

			_context.Entry(await GetProductCategoryAsync(id)).CurrentValues.SetValues(productCategory);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductCategoryExists(id))
				{
					throw new ArgumentException("ProductCategory not found");
				}
				else
				{
					throw;
				}
			}

			return productCategory;
		}

		private bool ProductCategoryExists(Guid id)
		{
			return _context.ProductCategory.Any(e => e.Id == id);
		}
	}
}
