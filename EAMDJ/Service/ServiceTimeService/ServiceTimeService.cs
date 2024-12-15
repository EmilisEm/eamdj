using EAMDJ.Dto.ServiceTimeDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.ServiceTimeRepository;

namespace EAMDJ.Service.ServiceTimeService
{
	public class ServiceTimeService : IServiceTimeService
	{
		private readonly IServiceTimeRepository _repository;

		public ServiceTimeService(IServiceTimeRepository repository)
		{
			_repository = repository;
		}

		public async Task<ServiceTimeResponseDto> CreateServiceTimeAsync(ServiceTimeCreateDto product)
		{
			ServiceTime created = await _repository.CreateServiceTimeAsync(ServiceTimeMapper.FromDto(product));

			return ServiceTimeMapper.ToDto(created);


		}

		public async Task DeleteServiceTimeAsync(Guid id)
		{
			await _repository.DeleteServiceTimeAsync(id);
		}

		public async Task<IEnumerable<ServiceTimeResponseDto>> GetAllServiceTimesByProductIdAsync(Guid productCategoryId)
		{
			IEnumerable<ServiceTime> products = await _repository.GetAllServiceTimesByProductIdAsync(productCategoryId);

			return products.Select(ServiceTimeMapper.ToDto);
		}

		public async Task<ServiceTimeResponseDto> GetServiceTimeAsync(Guid id)
		{
			ServiceTime product = await _repository.GetServiceTimeAsync(id);

			return ServiceTimeMapper.ToDto(product);
		}

		public async Task<ServiceTimeResponseDto> UpdateServiceTimeAsync(Guid id, ServiceTimeUpdateDto product)
		{
			ServiceTime original = await _repository.GetServiceTimeAsync(id);

			ServiceTime updated = await _repository.UpdateServiceTimeAsync(id, ServiceTimeMapper.FromDto(product, original.Id, original.ServiceId));

			return ServiceTimeMapper.ToDto(updated);
		}
	}
}
