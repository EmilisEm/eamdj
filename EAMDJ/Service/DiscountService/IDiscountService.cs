using EAMDJ.Dto.DiscountDto;

namespace EAMDJ.Service.DiscountService
{
	public interface IDiscountService
	{
		Task<DiscountResponseDto> GetDiscountAsync(Guid id);
		Task<IEnumerable<DiscountResponseDto>> GetAllDiscountsByProductIdAsync(Guid productId);
		Task DeleteDiscountAsync(Guid id);
		Task<DiscountResponseDto> CreateDiscountAsync(DiscountCreateDto discount);
	}
}
