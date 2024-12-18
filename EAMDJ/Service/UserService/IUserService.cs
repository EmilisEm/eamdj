using EAMDJ.Dto.UserDto;

namespace EAMDJ.Service.UserService
{
	public interface IUserService
	{
		Task<UserResponseDto> GetUserAsync(Guid id);
		Task<UserResponseDto> GetUserByUsernameAsync(string id);
		Task<IEnumerable<UserResponseDto>> GetAllUsersByBusinessIdAsync(Guid businessId);
		Task<UserResponseDto> UpdateUserAsync(Guid id, UserUpdateDto user);
		Task DeleteUserAsync(Guid id);
		Task<UserResponseDto> CreateUserAsync(UserCreateDto user);
	}
}
