using EAMDJ.Dto.BusinessDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository;

namespace EAMDJ.Service.BusinessService.BusinessService
{
	public class BusinessService : IBusinessService
	{
		private readonly IBusinessRepository _repository;

		public BusinessService(IBusinessRepository repository)
		{
			_repository = repository;
		}

		public async Task<BusinessResponseDto> CreateBusinessAsync(BusinessCreateDto business)
		{
			Business created = await _repository.CreateBusinessAsync(BusinessMapper.FromDto(business));

			return BusinessMapper.ToDto(created);


		}

		public async Task DeleteBusinessAsync(Guid id)
		{
			await _repository.DeleteBusinessAsync(id);
		}

		public async Task<IEnumerable<BusinessResponseDto>> GetAllBusinessAsync()
		{
			IEnumerable<Business> businesses = await _repository.GetAllBusinessAsync();

			return businesses.Select(BusinessMapper.ToDto);
		}

		public async Task<BusinessResponseDto> GetBusinessAsync(Guid id)
		{
			Business business = await _repository.GetBusinessAsync(id);

			return BusinessMapper.ToDto(business);
		}

		public async Task<BusinessResponseDto> UpdateBusinessAsync(Guid id, BusinessUpdateDto business)
		{
			Business updated = await _repository.UpdateBusinessAsync(id, BusinessMapper.FromDto(business, id));

			return BusinessMapper.ToDto(updated);
		}
	}
}
