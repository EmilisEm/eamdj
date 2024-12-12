﻿using EAMDJ.Dto.TaxDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class TaxMapper
	{
		public static TaxResponseDto ToDto(Tax from)
		{
			return new TaxResponseDto()
			{
				Id = from.Id,
				CategoryId = from.ProductCategoryId,
			};
		}
		public static Tax FromDto(TaxCreateDto from)
		{
			return new Tax()
			{
				Id = Guid.NewGuid(),
				ProductCategoryId = from.CategoryId,
				Name = from.Name,
				Percentage = from.Percentage,
			};
		}
		public static Tax FromDto(TaxUpdateDto from, Guid id, Guid categoryId)
		{
			return new Tax()
			{
				Id = id,
				ProductCategoryId = categoryId,
				Name = from.Name,
				Percentage = from.Percentage,
			};
		}
	}
}
