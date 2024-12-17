using EAMDJ.Model;

namespace EAMDJ.Repository
{
	public interface IBusinessRepository
	{
		Task<Business> GetBusinessAsync(Guid id);
		Task<IEnumerable<Business>> GetAllBusinessAsync();
		IQueryable<Business> GetQueryBusinessAsync();
		Task<Business> UpdateBusinessAsync(Guid id, Business business);
		Task DeleteBusinessAsync(Guid id);
		Task<Business> CreateBusinessAsync(Business business);

	}
}
