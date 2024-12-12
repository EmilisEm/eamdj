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
			Guid id = Guid.NewGuid();

			// TODO: Validate order and product existence. Throw exception

			_context.Product.Add(product);
			await _context.SaveChangesAsync();

			return product;
		}

		public async Task DeleteProductAsync(Guid id)
		{
			var product = await _context.Product.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.Product.Remove(product);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByProductCategoryIdAsync(Guid productCategoryId)
		{
			return await _context.Product.Where(it => it.CategoryId.Equals(productCategoryId)).ToListAsync();
		}

		public async Task<Product> GetProductAsync(Guid id)
		{
			var product = await _context.Product.FindAsync(id);

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

			_context.Entry(product).State = EntityState.Modified;

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

			return product;
		}

		private bool ProductExists(Guid id)
		{
			return _context.Product.Any(e => e.Id == id);
		}
	}
}
