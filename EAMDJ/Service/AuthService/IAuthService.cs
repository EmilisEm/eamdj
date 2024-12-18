namespace EAMDJ.Service.AuthService
{
	public interface IAuthService
	{
		bool AuthorizeToOwnerAndAdmin();
		bool AuthorizeToAdmin();
		bool AuthorizeForBusiness(Guid businessId);
	}
}
