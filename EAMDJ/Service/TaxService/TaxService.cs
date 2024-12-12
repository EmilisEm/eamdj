using EAMDJ.Dto.TaxDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.TaxRepository;

namespace EAMDJ.Service.TaxService
{
	public class TaxService : ITaxService
	{
		private readonly ITaxRepository _repository;

		public TaxService(ITaxRepository repository)
		{
			_repository = repository;
		}

		public async Task<TaxResponseDto> CreateTaxAsync(TaxCreateDto tax)
		{
			Tax created = await _repository.CreateTaxAsync(TaxMapper.FromDto(tax));

			return TaxMapper.ToDto(created);


		}

		public async Task DeleteTaxAsync(Guid id)
		{
			await _repository.DeleteTaxAsync(id);
		}

		public async Task<IEnumerable<TaxResponseDto>> GetAllTaxesByCategoryIdAsync(Guid categoryId)
		{
			IEnumerable<Tax> taxs = await _repository.GetAllTaxesByCategoryIdAsync(categoryId);

			return taxs.Select(TaxMapper.ToDto);
		}

		public async Task<TaxResponseDto> GetTaxAsync(Guid id)
		{
			Tax tax = await _repository.GetTaxAsync(id);

			return TaxMapper.ToDto(tax);
		}

		public async Task<TaxResponseDto> UpdateTaxAsync(Guid id, TaxUpdateDto tax)
		{
			Tax original = await _repository.GetTaxAsync(id);

			Tax updated = await _repository.UpdateTaxAsync(id, TaxMapper.FromDto(tax, original.Id, original.ProductCategoryId));

			return TaxMapper.ToDto(updated);
		}
	}
}
