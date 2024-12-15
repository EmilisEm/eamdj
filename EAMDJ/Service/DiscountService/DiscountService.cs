using EAMDJ.Dto.DiscountDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.DiscountRepository;

namespace EAMDJ.Service.DiscountService
{
	public class DiscountService : IDiscountService
	{
		private readonly IDiscountRepository _repository;

		public DiscountService(IDiscountRepository repository)
		{
			_repository = repository;
		}

		public async Task<DiscountResponseDto> CreateDiscountAsync(DiscountCreateDto product)
		{
			Discount created = await _repository.CreateDiscountAsync(DiscountMapper.FromDto(product));

			return DiscountMapper.ToDto(created);


		}

		public async Task DeleteDiscountAsync(Guid id)
		{
			await _repository.DeleteDiscountAsync(id);
		}

		public async Task<IEnumerable<DiscountResponseDto>> GetAllDiscountsByProductIdAsync(Guid productCategoryId)
		{
			IEnumerable<Discount> products = await _repository.GetAllDiscountsByProductIdAsync(productCategoryId);

			return products.Select(DiscountMapper.ToDto);
		}

		public async Task<IEnumerable<DiscountResponseDto>> GetAllDiscountsByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<Discount> products = await _repository.GetAllDiscountsByBusinessIdAsync(businessId);

			return products.Select(DiscountMapper.ToDto);
		}

		public async Task<DiscountResponseDto> GetDiscountAsync(Guid id)
		{
			Discount product = await _repository.GetDiscountAsync(id);

			return DiscountMapper.ToDto(product);
		}
	}
}
