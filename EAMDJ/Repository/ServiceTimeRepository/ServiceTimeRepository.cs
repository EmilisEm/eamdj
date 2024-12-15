using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.ServiceTimeRepository
{
	public class ServiceTimeRepository : IServiceTimeRepository
	{
		private readonly ServiceAppContext _context;

		public ServiceTimeRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<ServiceTime> CreateServiceTimeAsync(ServiceTime serviceTime)
		{
			_context.ServiceTime.Add(serviceTime);
			await _context.SaveChangesAsync();

			return serviceTime;
		}

		public async Task DeleteServiceTimeAsync(Guid id)
		{
			var serviceTime = await _context.ServiceTime.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.ServiceTime.Remove(serviceTime);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ServiceTime>> GetAllServiceTimesByProductIdAsync(Guid productCategoryId)
		{
			return await _context.ServiceTime.Where(it => it.ServiceId.Equals(productCategoryId)).ToListAsync();
		}

		public async Task<ServiceTime> GetServiceTimeAsync(Guid id)
		{
			var serviceTime = await _context.ServiceTime.FindAsync(id);

			if (serviceTime == null)
			{
				throw new ArgumentException("ServiceTime not found");
			}

			return serviceTime;
		}

		public async Task<ServiceTime> UpdateServiceTimeAsync(Guid id, ServiceTime serviceTime)
		{
			if (id != serviceTime.Id)
			{
				throw new ArgumentException("ServiceTime not found");
			}

			_context.Entry(await GetServiceTimeAsync(id)).CurrentValues.SetValues(serviceTime);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ServiceTimeExists(id))
				{
					throw new ArgumentException("ServiceTime not found");
				}
				else
				{
					throw;
				}
			}

			return serviceTime;
		}

		private bool ServiceTimeExists(Guid id)
		{
			return _context.ServiceTime.Any(e => e.Id == id);
		}
	}
}
