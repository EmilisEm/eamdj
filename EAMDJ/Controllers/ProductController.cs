using EAMDJ.Dto;
using EAMDJ.Service.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("by-product-category/{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByProductCategoryId(Guid id)
        {
            return Ok(await _service.GetAllProductsByProductCategoryIdAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            return Ok(await _service.GetProductAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _service.UpdateProductAsync(id, product);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto product)
        {
            return await _service.CreateProductAsync(product);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
			await _service.DeleteProductAsync(id);

            return NoContent();
        }

	}
}
