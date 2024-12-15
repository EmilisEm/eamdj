using EAMDJ.Dto.ProductModifierDto;

namespace EAMDJ.Service.ProductModifierService
{
	public interface IProductModifierService
	{
		Task<ProductModifierResponseDto> GetProductModifierAsync(Guid id);
		Task<IEnumerable<ProductModifierResponseDto>> GetAllProductModifiersByProductIdAsync(Guid productId);
		Task<ProductModifierResponseDto> UpdateProductModifierAsync(Guid id, ProductModifierUpdateDto productModifier);
		Task DeleteProductModifierAsync(Guid id);
		Task<ProductModifierResponseDto> CreateProductModifierAsync(ProductModifierCreateDto productModifier);
	}
}
