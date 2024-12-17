using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.UserRepository
{
	public class UserRepository : IUserRepository
	{
		private readonly ServiceAppContext _context;

		public UserRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<User> CreateUserAsync(User user)
		{
			_context.User.Add(user);
			await _context.SaveChangesAsync();

			return user;
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var user = await _context.User.FindAsync(id) ?? throw new ArgumentException("User not found");
			_context.User.Remove(user);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetAllUsersByBusinessIdAsync(Guid businessId)
		{
			return await _context.User.Where(it => it.BusinessId.Equals(businessId)).ToListAsync();
		}

		public IQueryable<User> GetQueryUsersByBusinessIdAsync(Guid businessId)
		{
			return _context.User.Where(it => it.BusinessId.Equals(businessId)).AsQueryable();
		}

		public async Task<User> GetUserAsync(Guid id)
		{
			var user = await _context.User.FindAsync(id);

			if (user == null)
			{
				throw new ArgumentException("User not found");
			}

			return user;
		}

		public async Task<User> UpdateUserAsync(Guid id, User user)
		{
			if (id != user.Id)
			{
				throw new ArgumentException("User not found repo");
			}

			_context.Entry(await GetUserAsync(id)).CurrentValues.SetValues(user);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(id))
				{
					throw new ArgumentException("User not found");
				}
				else
				{
					throw;
				}
			}

			return user;
		}

		private bool UserExists(Guid id)
		{
			return _context.User.Any(e => e.Id == id);
		}
	}
}
