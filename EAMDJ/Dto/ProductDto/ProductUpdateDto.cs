﻿namespace EAMDJ.Dto.ProductDto
{
	public class ProductUpdateDto
	{
		public decimal Price { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
	}
}
