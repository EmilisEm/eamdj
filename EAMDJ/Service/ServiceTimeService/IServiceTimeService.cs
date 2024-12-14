using EAMDJ.Dto.ServiceTimeDto;

namespace EAMDJ.Service.ServiceTimeService
{
	public interface IServiceTimeService
	{
		Task<ServiceTimeResponseDto> GetServiceTimeAsync(Guid id);
		Task<IEnumerable<ServiceTimeResponseDto>> GetAllServiceTimesByProductIdAsync(Guid productId);
		Task<ServiceTimeResponseDto> UpdateServiceTimeAsync(Guid id, ServiceTimeUpdateDto serviceTime);
		Task DeleteServiceTimeAsync(Guid id);
		Task<ServiceTimeResponseDto> CreateServiceTimeAsync(ServiceTimeCreateDto serviceTime);
	}
}
