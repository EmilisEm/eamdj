﻿namespace EAMDJ.Dto.ServiceTimeDto
{
	public class ServiceTimeResponseDto
	{
		public Guid Id { get; set; }
		public Guid ServiceId { get; set; }
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
	}
}
