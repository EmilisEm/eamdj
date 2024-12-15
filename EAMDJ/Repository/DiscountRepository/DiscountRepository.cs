using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.DiscountRepository
{
	public class DiscountRepository : IDiscountRepository
	{
		private readonly ServiceAppContext _context;

		public DiscountRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Discount> CreateDiscountAsync(Discount discount)
		{
			_context.Discount.Add(discount);
			await _context.SaveChangesAsync();

			return discount;
		}

		public async Task DeleteDiscountAsync(Guid id)
		{
			var discount = await _context.Discount.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.Discount.Remove(discount);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Discount>> GetAllDiscountsByProductIdAsync(Guid productId)
		{
			return await _context.Discount.Where(it => productId.Equals(it.ProductId)).ToListAsync();
		}

		public async Task<IEnumerable<Discount>> GetAllDiscountsByBusinessIdAsync(Guid businessId)
		{
			return await _context.Discount.Where(it => businessId.Equals(it.BusinessId) && it.ProductId == null).ToListAsync();
		}

		public async Task<Discount?> GetDiscountAsync(Guid? id)
		{
			var discount = await _context.Discount.FindAsync(id);

			if (discount == null)
			{
				throw new ArgumentException("Discount not found");
			}

			return discount;
		}

		public async Task<Discount> UpdateDiscountAsync(Guid id, Discount discount)
		{
			if (id != discount.Id)
			{
				throw new ArgumentException("Discount not found");
			}

			_context.Entry(await GetDiscountAsync(id)).CurrentValues.SetValues(discount);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DiscountExists(id))
				{
					throw new ArgumentException("Discount not found");
				}
				else
				{
					throw;
				}
			}

			return discount;
		}

		private bool DiscountExists(Guid id)
		{
			return _context.Discount.Any(e => e.Id == id);
		}
	}
}
