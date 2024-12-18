using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EAMDJ.Dto.UserDto;
using EAMDJ.Model;
using EAMDJ.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EAMDJ.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IUserService _userService;

		public AuthController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel login)
		{
			UserResponseDto user = await _userService.GetUserByUsernameAsync(login.Username);
			if (user == default)
			{
				return Unauthorized("Invalid username or password.");
			}

			string userBusiness = "admin";
			if (!(user.BusinessId == Guid.Empty) && !(user.BusinessId == null))
			{
				userBusiness = user.BusinessId.ToString();
			}

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, userBusiness),
				new Claim(ClaimTypes.Role, user.UserType.ToString()),
				new Claim(ClaimTypes.Authentication, user.Id.ToString())
			};

			var secret = _configuration["Jwt:Secret"];
			if (string.IsNullOrEmpty(secret))
			{
				return BadRequest("Invalid configuration for JWT secret.");
			}
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds
			);

			return Ok(new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token)
			});
		}

	}
}
