using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.ProductRepository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ServiceAppContext _context;

		public ProductRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Product> CreateProductAsync(Product product)
		{
			_context.Product.Add(product);
			await _context.SaveChangesAsync();

			return await GetProductAsync(product.Id);
		}

		public async Task DeleteProductAsync(Guid id)
		{
			var product = await _context.Product.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.Product.Remove(product);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByProductCategoryIdAsync(Guid productCategoryId)
		{
			return await _context.Product.Include(it => it.ProductModifiers).Include(it => it.Category).Include(it => it.Discounts).Where(it => it.CategoryId.Equals(productCategoryId)).ToListAsync();
		}

		public async Task<Product> GetProductAsync(Guid id)
		{
			var product = await _context.Product.Include(it => it.ProductModifiers).Include(it => it.Discounts).Include(it => it.Category).Where(it => it.Id == id).FirstAsync();

			if (product == null)
			{
				throw new ArgumentException("Product not found");
			}

			return product;
		}

		public async Task<Product> UpdateProductAsync(Guid id, Product product)
		{
			if (id != product.Id)
			{
				throw new ArgumentException("Product not found");
			}

			product.ProductModifiers = await _context.ProductModifier.Where(it => it.ProductId == id).ToListAsync();

			_context.Entry(await GetProductAsync(id)).CurrentValues.SetValues(product);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(id))
				{
					throw new ArgumentException("Product not found");
				}
				else
				{
					throw;
				}
			}

			return await GetProductAsync(product.Id);
		}

		private bool ProductExists(Guid id)
		{
			return _context.Product.Any(e => e.Id == id);
		}
	}
}
