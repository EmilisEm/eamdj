using EAMDJ.Model;

namespace EAMDJ.Repository.TaxRepository
{
	public interface ITaxRepository
	{
		Task<Tax> GetTaxAsync(Guid id);
		Task<Tax> UpdateTaxAsync(Guid id, Tax tax);
		Task DeleteTaxAsync(Guid id);
		Task<Tax> CreateTaxAsync(Tax tax);
	}
}
