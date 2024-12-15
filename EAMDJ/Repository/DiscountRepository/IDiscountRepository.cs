using EAMDJ.Model;

namespace EAMDJ.Repository.DiscountRepository
{
	public interface IDiscountRepository
	{
		Task<Discount> GetDiscountAsync(Guid id);
		Task<IEnumerable<Discount>> GetAllDiscountsByProductIdAsync(Guid productId);
		Task<Discount> UpdateDiscountAsync(Guid id, Discount discount);
		Task DeleteDiscountAsync(Guid id);
		Task<Discount> CreateDiscountAsync(Discount discount);
	}
}
