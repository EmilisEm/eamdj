using EAMDJ.Dto.TaxDto;

namespace EAMDJ.Service.TaxService
{
	public interface ITaxService
	{
		Task<TaxResponseDto> GetTaxAsync(Guid id);
		Task<TaxResponseDto> UpdateTaxAsync(Guid id, TaxUpdateDto tax);
		Task DeleteTaxAsync(Guid id);
		Task<TaxResponseDto> CreateTaxAsync(TaxCreateDto tax);
	}
}
