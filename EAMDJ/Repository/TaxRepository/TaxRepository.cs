using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.TaxRepository
{
	public class TaxRepository : ITaxRepository
	{
		private readonly ServiceAppContext _context;

		public TaxRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Tax> CreateTaxAsync(Tax tax)
		{
			Guid id = Guid.NewGuid();

			// TODO: Validate order and tax existence. Throw exception

			_context.Tax.Add(tax);
			await _context.SaveChangesAsync();

			return tax;
		}

		public async Task DeleteTaxAsync(Guid id)
		{
			var tax = await _context.Tax.FindAsync(id) ?? throw new ArgumentException("Tax not found");
			_context.Tax.Remove(tax);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Tax>> GetAllTaxesByCategoryIdAsync(Guid categoryId)
		{
			return await _context.Tax.Where(it => it.ProductCategoryId.Equals(categoryId)).ToListAsync();
		}

		public async Task<Tax> GetTaxAsync(Guid id)
		{
			var tax = await _context.Tax.FindAsync(id);

			if (tax == null)
			{
				throw new ArgumentException("Tax not found");
			}

			return tax;
		}

		public async Task<Tax> UpdateTaxAsync(Guid id, Tax tax)
		{
			if (id != tax.Id)
			{
				throw new ArgumentException("Tax not found");
			}

			_context.Entry(await GetTaxAsync(id)).CurrentValues.SetValues(tax);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TaxExists(id))
				{
					throw new ArgumentException("Tax not found");
				}
				else
				{
					throw;
				}
			}

			return tax;
		}

		private bool TaxExists(Guid id)
		{
			return _context.Tax.Any(e => e.Id == id);
		}
	}
}
