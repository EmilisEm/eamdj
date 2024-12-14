using EAMDJ.Model;

namespace EAMDJ.Repository.ReservationRepository
{
	public interface IReservationRepository
	{
		Task<Reservation> GetReservationAsync(Guid id);
		Task<IEnumerable<Reservation>> GetAllReservationsByProductIdAsync(Guid productId);
		Task<Reservation> UpdateReservationAsync(Guid id, Reservation reservation);
		Task DeleteReservationAsync(Guid id);
		Task<Reservation> CreateReservationAsync(Reservation reservation);
	}
}
