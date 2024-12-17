using EAMDJ.Dto.BusinessDto;
using EAMDJ.Dto.OrderDto;
using EAMDJ.Dto.Shared;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository;
using Microsoft.EntityFrameworkCore;

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
		public async Task<PaginatedResult<BusinessResponseDto>> GetAllBusinessAsync(int page, int pageSize)
		{
			var skip = (page - 1) * pageSize;
			var query = _repository.GetQueryBusinessAsync();
			var totalCount = await query.CountAsync();

			var businesses = await query
				.Skip(skip)
				.Take(pageSize)
				.ToListAsync();

			var businessDtos = businesses.Select(BusinessMapper.ToDto).ToList();

			return new PaginatedResult<BusinessResponseDto>
			{
				Items = businessDtos,
				TotalCount = totalCount,
				Page = page,
				PageSize = pageSize
			};
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
