﻿using EAMDJ.Model;

namespace EAMDJ.Dto.UserDto
{
	public class UserUpdateDto
	{
		public string Username { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public UserType UserType { get; set; }
	}
}