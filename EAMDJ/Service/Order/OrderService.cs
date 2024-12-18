using EAMDJ.Dto.OrderDto;
using EAMDJ.Dto.Shared;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.DiscountRepository;
using EAMDJ.Repository.OrderItemRepository;
using EAMDJ.Repository.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Service.OrderService

{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IDiscountRepository _discountRepository;

		public OrderService(IOrderRepository repository, IOrderItemRepository orderItemRepository, IDiscountRepository discountRepository)
		{
			_repository = repository;
			_orderItemRepository = orderItemRepository;
			_discountRepository = discountRepository;
		}

		public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto order)
		{
			Order created = await _repository.CreateOrderAsync(OrderMapper.FromDto(order));

			var price = GetPayedAmount(created);

			return OrderMapper.ToDto(created, price.Item1 + price.Item2, price.Item2);
		}

		public async Task DeleteOrderAsync(Guid id)
		{
			await _repository.DeleteOrderAsync(id);
		}

		public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<Order> orderes = await _repository.GetAllOrdersByBusinessIdAsync(businessId);


			return await Task.WhenAll(orderes.Select(async it =>
			{
				var price = GetPayedAmount(it);

				return OrderMapper.ToDto(it, price.Item1 + price.Item2, price.Item2);
			}));
		}

		public async Task<OrderResponseDto> GetOrderAsync(Guid id)
		{
			Order order = await _repository.GetOrderAsync(id);
			IEnumerable<OrderItem> items = await _orderItemRepository.GetAllOrderItemsByOrderIdAsync(id);

			order.OrderItems = items;
			var price = GetPayedAmount(order);

			return OrderMapper.ToDto(order, price.Item1 + price.Item2, price.Item2);
		}
		public async Task<PaginatedResult<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId, int page, int pageSize)
		{
			var skip = (page - 1) * pageSize;
			var query = _repository.GetQueryOrdersByBusinessIdAsync(businessId);
			var totalCount = await query.CountAsync();

			var orders = await query
				.Skip(skip)
				.Take(pageSize)
				.ToListAsync();

			var orderDtos = orders.Select(o =>
			{
				var price = GetPayedAmount(o);
				return OrderMapper.ToDto(o, price.Item1 + price.Item2, price.Item2);
			}).ToList();

			return new PaginatedResult<OrderResponseDto>
			{
				Items = orderDtos,
				TotalCount = totalCount,
				Page = page,
				PageSize = pageSize
			};
		}


		public async Task<OrderResponseDto> UpdateOrderAsync(Guid id, OrderUpdateDto order)
		{
			Order original = await _repository.GetOrderAsync(id);
			Order mapped = OrderMapper.FromDto(order, original);

			if (mapped.DiscountId != null)
			{
				mapped.Discount = await _discountRepository.GetDiscountAsync(mapped.DiscountId);
			}

			Order updated = await _repository.UpdateOrderAsync(id, mapped, original);

			var price = GetPayedAmount(updated);

			return OrderMapper.ToDto(updated, price.Item1 + price.Item2, price.Item2);
		}

		private static Tuple<decimal, decimal> GetPayedAmount(Order order)
		{
			decimal totalPrice = 0;
			decimal totalTax = 0;
			foreach (OrderItem item in order.OrderItems)
			{
				if (item == null)
				{
					throw new ArgumentException("Failed to fetch order items for order " + order.Id);
				}

				var product = item.Product;
				var category = product.Category;

				decimal totalItemTax = 0;
				if (category.Taxes == null)
				{
					throw new ArgumentException("Invalid response from database while getting taxes");
				}

				foreach (Tax tax in category.Taxes)
				{
					totalItemTax += tax.Percentage;
				}

				decimal totalModPrice = 0;
				decimal totalModTax = 0;
				foreach (ProductModifier mod in item.ProductModifiers)
				{
					totalModPrice += mod.Price * item.Quantity;
					totalModTax += mod.Price / 100 * totalItemTax * item.Quantity;
				}

				decimal orderItemTax = product.Price / 100 * totalItemTax * item.Quantity + totalModTax;
				decimal orderItemPrice = product.Price * item.Quantity + totalModPrice;

				var orderItemTotal = orderItemPrice + orderItemTax;

				Discount? itemDiscount = item?.Product?.Discounts?.Where(it => it.Expires > DateTime.UtcNow).OrderByDescending(it => it.Amount).FirstOrDefault();

				if (itemDiscount == null)
				{
					totalTax += orderItemTax;
					totalPrice += orderItemPrice;
				}
				else if (itemDiscount.IsFlat)
				{
					totalTax += item?.Quantity * itemDiscount.Amount > orderItemTotal ? 0 : orderItemTax - itemDiscount.Amount * item.Quantity * (orderItemTax / orderItemTotal);
					totalPrice += item?.Quantity * itemDiscount.Amount > orderItemTotal ? 0 : orderItemPrice - itemDiscount.Amount * item.Quantity * (orderItemPrice / orderItemTotal);
				}
				else
				{
					totalTax += (1 - itemDiscount.Amount / 100) * orderItemTax;
					totalPrice += (1 - itemDiscount.Amount / 100) * orderItemPrice;
				}
			}
			var total = totalTax + totalPrice;
			if (order.Discount != null && order.Discount.Expires > DateTime.UtcNow)
			{
				if (order.Discount.IsFlat)
				{
					var shouldFloor = order.Discount.Amount > (total);
					totalTax = shouldFloor ? 0 : totalTax - (order.Discount.Amount * (totalTax / (total)));
					totalPrice = shouldFloor ? 0 : totalPrice - (order.Discount.Amount * (totalPrice / (total)));
				}
				else
				{
					totalTax *= 1 - order.Discount.Amount / 100;
					totalPrice *= 1 - order.Discount.Amount / 100;
				}
			}

			return Tuple.Create(totalPrice, totalTax);
		}

		public async Task<OrderResponseDto> PaySumForOrder(Guid id, decimal sum)
		{
			ArgumentOutOfRangeException.ThrowIfNegative(sum);

			var order = await _repository.GetOrderAsync(id);

			// If order is not open for payment throw exception
			if (order.Status != OrderStatus.Open || order.Status != OrderStatus.PartiallyPaid)
			{
				throw new InvalidOperationException("Order is not open for payment.");
			}

			// This actually returns a tuple of the full price of the order and the total taxes
			var priceWithTaxes = GetPayedAmount(order);
			var price = priceWithTaxes.Item1;
			var taxes = priceWithTaxes.Item2;
			var unpayedAmount = price - order.PayedAmount;

			ArgumentOutOfRangeException.ThrowIfGreaterThan(sum, unpayedAmount);

			order.PayedAmount += sum;
			// Update order status depending on payment amount
			if (order.PayedAmount == price)
			{
				order.Status = OrderStatus.Paid;
			}
			else
			{
				order.Status = OrderStatus.PartiallyPaid;
			}

			return OrderMapper.ToDto(order, price, taxes);
		}
	}
}
