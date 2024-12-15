using EAMDJ.Dto.OrderDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.CategoryRepository;
using EAMDJ.Repository.DiscountRepository;
using EAMDJ.Repository.OrderItemRepository;
using EAMDJ.Repository.OrderRepository;
using EAMDJ.Repository.ProductRepository;

namespace EAMDJ.Service.OrderService

{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IDiscountRepository _discountRepository;

		public OrderService(IOrderRepository repository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IDiscountRepository discountRepository)
		{
			_repository = repository;
			_orderItemRepository = orderItemRepository;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
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
				totalTax += product.Price / 100 * totalItemTax * item.Quantity + totalModTax;
				totalPrice += product.Price * item.Quantity + totalModPrice;

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
			}

			return Tuple.Create(totalPrice, totalTax);
		}
	}
}
