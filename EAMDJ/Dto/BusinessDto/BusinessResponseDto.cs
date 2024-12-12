﻿namespace EAMDJ.Dto.BusinessDto
{
	public class BusinessResponseDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public Guid OwnerId { get; set; }
	}
}
