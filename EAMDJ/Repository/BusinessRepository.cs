using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository
{
	public class BusinessRepository : IBusinessRepository
	{
		private readonly ServiceAppContext _context;

		public BusinessRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Business> CreateBusinessAsync(Business business)
		{
			_context.Business.Add(business);
			await _context.SaveChangesAsync();

			return business;
		}

		public async Task DeleteBusinessAsync(Guid id)
		{
			var business = await _context.Business.FindAsync(id) ?? throw new ArgumentException("Business not found");
			_context.Business.Remove(business);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Business>> GetAllBusinessAsync()
		{
			return await _context.Business.ToListAsync();
		}

		public async Task<Business> GetBusinessAsync(Guid id)
		{
			var business = await _context.Business.FindAsync(id);

			if (business == null)
			{
				throw new ArgumentException("Business not found");
			}

			return business;
		}
		public IQueryable<Business> GetQueryBusinessAsync()
		{
			return _context.Business.AsQueryable();
		}

		public async Task<Business> UpdateBusinessAsync(Guid id, Business business)
		{
			if (id != business.Id)
			{
				throw new ArgumentException("Business not found");
			}

			_context.Entry(business).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BusinessExists(id))
				{
					throw new ArgumentException("Business not found");
				}
				else
				{
					throw;
				}
			}

			return business;
		}

		private bool BusinessExists(Guid id)
		{
			return _context.Business.Any(e => e.Id == id);
		}
	}
}