using EAMDJ.Dto.BusinessDto;

namespace EAMDJ.Service.BusinessService.BusinessService
{
	public interface IBusinessService
	{
		Task<BusinessResponseDto> GetBusinessAsync(Guid id);
		Task<IEnumerable<BusinessResponseDto>> GetAllBusinessAsync();
		Task<BusinessResponseDto> UpdateBusinessAsync(Guid id, BusinessUpdateDto business);
		Task DeleteBusinessAsync(Guid id);
		Task<BusinessResponseDto> CreateBusinessAsync(BusinessCreateDto business);
	}
}
