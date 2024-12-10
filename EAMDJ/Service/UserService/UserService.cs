using EAMDJ.Dto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.UserRepository;

namespace EAMDJ.Service.UserService
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _repository;

		public UserService(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<UserDto> CreateUserAsync(UserDto user)
		{
			User created = await _repository.CreateUserAsync(UserMapper.FromDto(user));

			return UserMapper.ToDto(created);


		}

		public async Task DeleteUserAsync(Guid id)
		{
			await _repository.DeleteUserAsync(id);
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<User> productCategories = await _repository.GetAllUsersByBusinessIdAsync(businessId);

			return productCategories.Select(UserMapper.ToDto);
		}

		public async Task<UserDto> GetUserAsync(Guid id)
		{
			User user = await _repository.GetUserAsync(id);

			return UserMapper.ToDto(user);
		}

		public async Task<UserDto> UpdateUserAsync(Guid id, UserDto user)
		{
			User updated = await _repository.UpdateUserAsync(id, UserMapper.FromDto(user));

			return UserMapper.ToDto(updated);
		}
	}
}
