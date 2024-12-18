﻿using EAMDJ.Dto.UserDto;
using EAMDJ.Service.UserService;
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
		public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsersByBusinessId(Guid id,
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20)
		{
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
