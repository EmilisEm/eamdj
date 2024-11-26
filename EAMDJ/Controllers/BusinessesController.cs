using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessDto>>> GetBusiness()
        {
            return Ok(await _service.GetAllBusinessAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessDto>> GetBusiness(Guid id)
        {
            return Ok(await _service.GetBusinessAsync(id));
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BusinessDto>> PostBusiness(BusinessDto business)
        {
            return await _service.CreateBusinessAsync(business);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
        {
			await _service.DeleteBusinessAsync(id);

            return NoContent();
        }
    }
}
