using EAMDJ.Model;

namespace EAMDJ.Repository.TaxRepository
{
	public interface ITaxRepository
	{
		Task<Tax> GetTaxAsync(Guid id);
		Task<IEnumerable<Tax>> GetTaxByBusinessAsync(Guid id);
		Task<IEnumerable<Tax>> GetAllByIdsAsync(IEnumerable<Guid> ids);
		Task<Tax> UpdateTaxAsync(Guid id, Tax tax);
		Task DeleteTaxAsync(Guid id);
		Task<Tax> CreateTaxAsync(Tax tax);
	}
}
