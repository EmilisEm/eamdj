using EAMDJ.Model;

namespace EAMDJ.Repository.ProductModifierRepository
{
	public interface IProductModifierRepository
	{
		Task<ProductModifier> GetProductModifierAsync(Guid id);
		Task<IEnumerable<ProductModifier>> GetAllProductModifiersByProductIdAsync(Guid productId);
		Task<ProductModifier> UpdateProductModifierAsync(Guid id, ProductModifier productModifier);
		Task DeleteProductModifierAsync(Guid id);
		Task<ProductModifier> CreateProductModifierAsync(ProductModifier productModifier);
	}
}
