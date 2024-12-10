using EAMDJ.Dto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class UserMapper
	{
		public static UserDto ToDto(User from)
		{
			return new UserDto()
			{
				Id = from.Id,
				Username = from.Username,
				BusinessId = from.BusinessId,
				FirstName = from.FirstName,
				LastName = from.LastName,
				Password = from.Password,
				UserType = from.UserType,
			};
		}
		public static User FromDto(UserDto from)
		{
			return new User()
			{
				Id = from.Id,
				Username = from.Username,
				BusinessId = from.BusinessId,
				FirstName = from.FirstName,
				LastName = from.LastName,
				Password = from.Password,
				UserType = from.UserType,
			};
		}
	}
}
