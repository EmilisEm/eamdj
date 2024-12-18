using EAMDJ.Dto.BusinessDto;
using EAMDJ.Dto.Shared;

namespace EAMDJ.Service.BusinessService.BusinessService
{
	public interface IBusinessService
	{
		Task<BusinessResponseDto> GetBusinessAsync(Guid id);
		Task<IEnumerable<BusinessResponseDto>> GetAllBusinessAsync();
		Task<PaginatedResult<BusinessResponseDto>> GetAllBusinessAsync(int page, int pageSize);
		Task<BusinessResponseDto> UpdateBusinessAsync(Guid id, BusinessUpdateDto business);
		Task DeleteBusinessAsync(Guid id);
		Task<BusinessResponseDto> CreateBusinessAsync(BusinessCreateDto business);
	}
}
