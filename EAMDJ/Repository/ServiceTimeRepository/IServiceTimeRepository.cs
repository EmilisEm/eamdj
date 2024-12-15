using EAMDJ.Model;

namespace EAMDJ.Repository.ServiceTimeRepository
{
	public interface IServiceTimeRepository
	{
		Task<ServiceTime> GetServiceTimeAsync(Guid id);
		Task<IEnumerable<ServiceTime>> GetAllServiceTimesByProductIdAsync(Guid productId);
		Task<ServiceTime> UpdateServiceTimeAsync(Guid id, ServiceTime serviceTime);
		Task DeleteServiceTimeAsync(Guid id);
		Task<ServiceTime> CreateServiceTimeAsync(ServiceTime serviceTime);
	}
}
