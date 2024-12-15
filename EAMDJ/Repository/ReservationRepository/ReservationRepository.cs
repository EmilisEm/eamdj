using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.ReservationRepository
{
	public class ReservationRepository : IReservationRepository
	{
		private readonly ServiceAppContext _context;

		public ReservationRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Reservation> CreateReservationAsync(Reservation reservation)
		{
			_context.Reservation.Add(reservation);

			reservation.ServiceTime = await _context.ServiceTime.FindAsync(reservation.ServiceTimeId);
			await _context.SaveChangesAsync();

			return reservation;
		}

		public async Task DeleteReservationAsync(Guid id)
		{
			var reservation = await _context.Reservation.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.Reservation.Remove(reservation);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Reservation>> GetAllReservationsByProductIdAsync(Guid productCategoryId)
		{
			return await _context.Reservation.Where(it => it.ProductId.Equals(productCategoryId)).Include(it => it.ServiceTime).ToListAsync();
		}

		public async Task<Reservation> GetReservationAsync(Guid id)
		{
			var reservation = await _context.Reservation.FindAsync(id);
			var serviceTime = await _context.ServiceTime.FindAsync(reservation?.ServiceTimeId);

			if (reservation == null)
			{
				throw new ArgumentException("Reservation not found");
			}
			reservation.ServiceTime = serviceTime;

			if (reservation == null)
			{
				throw new ArgumentException("Reservation not found");
			}

			return reservation;
		}

		public async Task<Reservation> UpdateReservationAsync(Guid id, Reservation reservation)
		{
			if (id != reservation.Id)
			{
				throw new ArgumentException("Reservation not found");
			}

			_context.Entry(await GetReservationAsync(id)).CurrentValues.SetValues(reservation);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ReservationExists(id))
				{
					throw new ArgumentException("Reservation not found");
				}
				else
				{
					throw;
				}
			}

			return reservation;
		}

		private bool ReservationExists(Guid id)
		{
			return _context.Reservation.Any(e => e.Id == id);
		}
	}
}
