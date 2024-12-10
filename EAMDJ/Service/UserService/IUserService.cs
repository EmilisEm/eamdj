using EAMDJ.Dto;

namespace EAMDJ.Service.UserService
{
	public interface IUserService
	{
		Task<UserDto> GetUserAsync(Guid id);
		Task<IEnumerable<UserDto>> GetAllUsersByBusinessIdAsync(Guid businessId);
		Task<UserDto> UpdateUserAsync(Guid id, UserDto user);
		Task DeleteUserAsync(Guid id);
		Task<UserDto> CreateUserAsync(UserDto user);
	}
}
