using EAMDJ.Dto;

namespace EAMDJ.Service
{
	public interface IBusinessService
	{
		Task<BusinessDto> GetBusinessAsync(Guid id);
		Task<IEnumerable<BusinessDto>> GetAllBusinessAsync();
		Task<BusinessDto> UpdateBusinessAsync(Guid id, BusinessDto business);
		Task DeleteBusinessAsync(Guid id);
		Task<BusinessDto> CreateBusinessAsync(BusinessDto business);
	}
}
