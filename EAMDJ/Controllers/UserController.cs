using EAMDJ.Dto;
using EAMDJ.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("by-business/{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByBusinessId(Guid id)
        {
            return Ok(await _service.GetAllUsersByBusinessIdAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            return Ok(await _service.GetUserAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UserDto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _service.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
        {
            return await _service.CreateUserAsync(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
			await _service.DeleteUserAsync(id);

            return NoContent();
        }
	}
}
