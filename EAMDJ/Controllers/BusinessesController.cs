using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAMDJ.Context;
using EAMDJ.Model;
using EAMDJ.Dto;
using EAMDJ.Service;

namespace EAMDJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IBusinessService _service;
        public BusinessesController(IBusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessDto>>> GetBusiness()
        {
            return Ok(await _service.GetAllBusinessAsync());
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessDto>> GetBusiness(Guid id)
        {
            return Ok(await _service.GetBusinessAsync(id));
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(Guid id, BusinessDto business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }

            await _service.UpdateBusinessAsync(id, business);
            return NoContent();
        }

        // POST: api/Businesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessDto>> PostBusiness(BusinessDto business)
        {
            return await _service.CreateBusinessAsync(business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
        {
			await _service.DeleteBusinessAsync(id);

            return NoContent();
        }
    }
}
