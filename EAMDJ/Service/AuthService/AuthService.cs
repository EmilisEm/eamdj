
using System.Security.Claims;
using EAMDJ.Model;
using EAMDJ.Repository.UserRepository;

namespace EAMDJ.Service.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public bool AuthorizeForBusiness(Guid businessId)
		{
			var user = _httpContextAccessor.HttpContext?.User;
			var userBusinessId = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
			System.Console.WriteLine("hfe");
			if (businessId.ToString().Equals(userBusinessId?.Value) || "admin".Equals(userBusinessId?.Value))
			{
				return true;
			}

			return false;
		}

		public bool AuthorizeToOwnerAndAdmin()
		{
			var user = _httpContextAccessor.HttpContext?.User;
			var userRole = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

			if (UserType.Admin.ToString().Equals(userRole?.Value) || UserType.BusinessOwner.ToString().Equals(userRole?.Value))
			{
				return true;
			}
			return false;
		}

		public bool AuthorizeToAdmin()
		{
			var user = _httpContextAccessor.HttpContext?.User;
			var userRole = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

			if (UserType.Admin.ToString().Equals(userRole?.Value))
			{
				return true;
			}
			return false;
		}
	}
}
