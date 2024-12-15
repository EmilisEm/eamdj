using EAMDJ.Dto.ReservationDto;

namespace EAMDJ.Service.ReservationService
{
	public interface IReservationService
	{
		Task<ReservationResponseDto> GetReservationAsync(Guid id);
		Task<IEnumerable<ReservationResponseDto>> GetAllReservationsByProductIdAsync(Guid productId);
		Task<ReservationResponseDto> UpdateReservationAsync(Guid id, ReservationUpdateDto reservation);
		Task DeleteReservationAsync(Guid id);
		Task<ReservationResponseDto> CreateReservationAsync(ReservationCreateDto reservation);
	}
}
