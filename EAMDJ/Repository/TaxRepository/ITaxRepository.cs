using EAMDJ.Model;

namespace EAMDJ.Repository.TaxRepository
{
	public interface ITaxRepository
	{
		Task<Tax> GetTaxAsync(Guid id);
		Task<IEnumerable<Tax>> GetAllTaxesByCategoryIdAsync(Guid categoryId);
		Task<Tax> UpdateTaxAsync(Guid id, Tax tax);
		Task DeleteTaxAsync(Guid id);
		Task<Tax> CreateTaxAsync(Tax tax);
	}
}
