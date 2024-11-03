using EAMDJ.Dto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository;

namespace EAMDJ.Service
{
	public class BusinessService : IBusinessService
	{
		private readonly IBusinessRepository _repository;

		public BusinessService(IBusinessRepository repository)
		{
			_repository = repository;
		}

		public async Task<BusinessDto> CreateBusinessAsync(BusinessDto business)
		{
			Business created = await _repository.CreateBusinessAsync(BusinessMapper.FromDto(business));

			return BusinessMapper.ToDto(created);


		}

		public async Task DeleteBusinessAsync(Guid id)
		{
			await _repository.DeleteBusinessAsync(id);
		}

		public async Task<IEnumerable<BusinessDto>> GetAllBusinessAsync()
		{
			IEnumerable<Business> businesses = await _repository.GetAllBusinessAsync();

			return businesses.Select(BusinessMapper.ToDto);
		}

		public async Task<BusinessDto> GetBusinessAsync(Guid id)
		{
			Business business = await _repository.GetBusinessAsync(id);

			return BusinessMapper.ToDto(business);
		}

		public async Task<BusinessDto> UpdateBusinessAsync(Guid id, BusinessDto business)
		{
			Business updated = await _repository.UpdateBusinessAsync(id, BusinessMapper.FromDto(business));

			return BusinessMapper.ToDto(updated);
		}
	}
}
