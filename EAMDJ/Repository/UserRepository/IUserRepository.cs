using EAMDJ.Model;

namespace EAMDJ.Repository.UserRepository
{
	public interface IUserRepository
	{

		Task<User> GetUserAsync(Guid id);
		Task<User> GetUserByUsernameAsync(string id);
		Task<IEnumerable<User>> GetAllUsersByBusinessIdAsync(Guid businessId);
		IQueryable<User> GetQueryUsersByBusinessIdAsync(Guid businessId);
		Task<User> UpdateUserAsync(Guid id, User user);
		Task DeleteUserAsync(Guid id);
		Task<User> CreateUserAsync(User user);
		Task<IEnumerable<User>> GetAllUsers();
	}
}
