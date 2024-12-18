using EAMDJ.Dto.ReservationDto;
using EAMDJ.Model;

namespace EAMDJ.Service.ReservationService
{
	public interface IReservationService
	{
		Task<ReservationResponseDto> GetReservationAsync(Guid id);
		Task<IEnumerable<ReservationResponseDto>> GetAllReservationsByProductIdAsync(Guid productId);
		Task<ReservationResponseDto> UpdateReservationAsync(Guid id, ReservationUpdateDto reservation);
		Task<Reservation> UpdateReservationStatusAsync(Guid id, ReservationStatus newStatus);
		Task DeleteReservationAsync(Guid id);
		Task<ReservationResponseDto> CreateReservationAsync(ReservationCreateDto reservation);
	}
}
