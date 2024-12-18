using EAMDJ.Dto.UserDto;
using EAMDJ.Service.AuthService;
using EAMDJ.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace EAMDJ.Controllers
{
	[Route("api/v1/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;
		private readonly IAuthService _authService;
		public UserController(IUserService service, IAuthService authService)
		{
			_service = service;
			_authService = authService;
		}

		[HttpGet("by-business/{id}")]
		public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsersByBusinessId(Guid id,
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20)
		{
			if (!_authService.AuthorizeForBusiness(id))
			{
				return Forbid();
			}
			if (page < 1 || pageSize < 1)
			{
				return BadRequest("Page and pageSize must be greater than 0.");
			}

			return Ok(await _service.GetAllUsersByBusinessIdAsync(id, page, pageSize));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserResponseDto>> GetUser(Guid id)
		{
			return Ok(await _service.GetUserAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(Guid id, UserUpdateDto user)
		{
			await _service.UpdateUserAsync(id, user);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<UserResponseDto>> PostUser(UserCreateDto user)
		{
			return await _service.CreateUserAsync(user);
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			if (!_authService.AuthorizeToOwnerAndAdmin())
			{
				return Forbid();
			}

			await _service.DeleteUserAsync(id);

			return NoContent();
		}

		[HttpGet("all")]
		public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
		{
			return Ok(await _service.GetAllUsers());
		}
	}
}
