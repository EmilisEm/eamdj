using EAMDJ.Dto.UserDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class UserMapper
	{
		public static UserResponseDto ToDto(User from)
		{
			return new UserResponseDto()
			{
				Id = from.Id,
				Username = from.Username,
				BusinessId = from.BusinessId,
				FirstName = from.FirstName,
				LastName = from.LastName,
				UserType = from.UserType,
			};
		}
		public static User FromDto(UserUpdateDto from, Guid businessId, string password)
		{
			return new User()
			{
				Id = Guid.NewGuid(),
				Username = from.Username,
				BusinessId = businessId,
				FirstName = from.FirstName,
				LastName = from.LastName,
				Password = password,
				UserType = from.UserType,
			};
		}
		public static User FromDto(UserCreateDto from)
		{
			return new User()
			{
				Id = Guid.NewGuid(),
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
