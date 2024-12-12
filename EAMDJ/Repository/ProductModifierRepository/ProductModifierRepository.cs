using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.ProductModifierRepository
{
	public class ProductModifierModifierRepository : IProductModifierRepository
	{
		private readonly ServiceAppContext _context;

		public ProductModifierModifierRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<ProductModifier> CreateProductModifierAsync(ProductModifier productModifier)
		{
			Guid id = Guid.NewGuid();

			// TODO: Validate order and productModifier existence. Throw exception

			_context.ProductModifier.Add(productModifier);
			await _context.SaveChangesAsync();

			return productModifier;
		}

		public async Task DeleteProductModifierAsync(Guid id)
		{
			var productModifier = await _context.ProductModifier.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.ProductModifier.Remove(productModifier);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ProductModifier>> GetAllProductModifiersByProductIdAsync(Guid productCategoryId)
		{
			return await _context.ProductModifier.Where(it => it.ProductId.Equals(productCategoryId)).ToListAsync();
		}

		public async Task<ProductModifier> GetProductModifierAsync(Guid id)
		{
			var productModifier = await _context.ProductModifier.FindAsync(id);

			if (productModifier == null)
			{
				throw new ArgumentException("ProductModifier not found");
			}

			return productModifier;
		}

		public async Task<ProductModifier> UpdateProductModifierAsync(Guid id, ProductModifier productModifier)
		{
			if (id != productModifier.Id)
			{
				throw new ArgumentException("ProductModifier not found");
			}

			_context.Entry(productModifier).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductModifierExists(id))
				{
					throw new ArgumentException("ProductModifier not found");
				}
				else
				{
					throw;
				}
			}

			return productModifier;
		}

		private bool ProductModifierExists(Guid id)
		{
			return _context.ProductModifier.Any(e => e.Id == id);
		}
	}
}
