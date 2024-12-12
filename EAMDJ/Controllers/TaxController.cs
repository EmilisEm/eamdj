﻿using EAMDJ.Dto.TaxDto;
using EAMDJ.Service.TaxService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/tax")]
	[ApiController]
	public class TaxController : ControllerBase
	{
		private readonly ITaxService _service;
		public TaxController(ITaxService service)
		{
			_service = service;
		}

		[HttpGet("by-product-category/{id}")]
		public async Task<ActionResult<IEnumerable<TaxResponseDto>>> GetTaxsByTaxCategoryId(Guid id)
		{
			return Ok(await _service.GetAllTaxesByCategoryIdAsync(id));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TaxResponseDto>> GetTax(Guid id)
		{
			return Ok(await _service.GetTaxAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTax(Guid id, TaxUpdateDto product)
		{
			await _service.UpdateTaxAsync(id, product);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<TaxResponseDto>> PostTax(TaxCreateDto product)
		{
			return await _service.CreateTaxAsync(product);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteTax(Guid id)
		{
			await _service.DeleteTaxAsync(id);

			return NoContent();
		}

	}
}
