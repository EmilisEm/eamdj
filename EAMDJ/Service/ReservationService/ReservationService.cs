using EAMDJ.Dto.ReservationDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.ReservationRepository;

namespace EAMDJ.Service.ReservationService
{
	public class ReservationService : IReservationService
	{
		private readonly IReservationRepository _repository;

		public ReservationService(IReservationRepository repository)
		{
			_repository = repository;
		}

		public async Task<ReservationResponseDto> CreateReservationAsync(ReservationCreateDto product)
		{
			Reservation created = await _repository.CreateReservationAsync(ReservationMapper.FromDto(product));

			return ReservationMapper.ToDto(created);


		}

		public async Task DeleteReservationAsync(Guid id)
		{
			await _repository.DeleteReservationAsync(id);
		}

		public async Task<IEnumerable<ReservationResponseDto>> GetAllReservationsByProductIdAsync(Guid productCategoryId)
		{
			IEnumerable<Reservation> products = await _repository.GetAllReservationsByProductIdAsync(productCategoryId);

			return products.Select(ReservationMapper.ToDto);
		}

		public async Task<ReservationResponseDto> GetReservationAsync(Guid id)
		{
			Reservation product = await _repository.GetReservationAsync(id);

			return ReservationMapper.ToDto(product);
		}

		public async Task<ReservationResponseDto> UpdateReservationAsync(Guid id, ReservationUpdateDto product)
		{
			Reservation original = await _repository.GetReservationAsync(id);

			Reservation updated = await _repository.UpdateReservationAsync(id, ReservationMapper.FromDto(product, original));

			return ReservationMapper.ToDto(updated);
		}
	}
}
