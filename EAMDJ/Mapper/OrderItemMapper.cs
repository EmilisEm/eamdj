using EAMDJ.Dto.OrderItemDto;
using EAMDJ.Model;

namespace EAMDJ.Mapper
{
	public static class OrderItemMapper
	{
		public static OrderItemResponseDto ToDto(OrderItem from)
		{
			return new OrderItemResponseDto()
			{
				Id = from.Id,
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
				BasePrice = from.Product.Price,
				TaxPercent = GetTaxForResponse(from),
				ProductModifiers = from.ProductModifiers.Select(ProductModifierMapper.ToDto),
			};
		}
		public static OrderItem FromDto(OrderItemCreateDto from)
		{
			return new OrderItem()
			{
				Id = Guid.NewGuid(),
				OrderId = from.OrderId,
				ProductId = from.ProductId,
				Quantity = from.Quantity,
				ProductModifiers = new List<ProductModifier>()
			};
		}
		public static OrderItem FromDto(OrderItemUpdateDto from, OrderItem original)
		{
			original.ProductId = from.ProductId;
			original.Quantity = from.Quantity;

			return original;
		}

		private static decimal GetTaxForResponse(OrderItem item)
		{
			if (item.Product == null)
			{
				throw new ArgumentException("Failed to load product " + item.ProductId + " while calculating product item [" + item.Id + "] tax");
			}

			if (item.Product.Category == null)
			{
				throw new ArgumentException("Failed to load product.category " + item.ProductId + " while calculating product item [" + item.Id + "] tax");
			}

			if (item.Product.Category.Taxes == null)
			{
				throw new ArgumentException("Failed to load product.category.tax " + item.ProductId + " while calculating product item [" + item.Id + "] tax");
			}

			return item.Product.Category.Taxes.Aggregate(decimal.Zero, (a, i) => a + i.Percentage);
		}
	}
}
