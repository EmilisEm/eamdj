using EAMDJ.Dto.OrderDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.CategoryRepository;
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

		public OrderService(IOrderRepository repository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_repository = repository;
			_orderItemRepository = orderItemRepository;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto order)
		{
			Order created = await _repository.CreateOrderAsync(OrderMapper.FromDto(order));

			return OrderMapper.ToDto(created);


		}

		public async Task DeleteOrderAsync(Guid id)
		{
			await _repository.DeleteOrderAsync(id);
		}

		public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<Order> orderes = await _repository.GetAllOrdersByBusinessIdAsync(businessId);

			return orderes.Select(OrderMapper.ToDto);
		}

		public async Task<OrderResponseDto> GetOrderAsync(Guid id)
		{
			Order order = await _repository.GetOrderAsync(id);
			IEnumerable<OrderItem> items = await _orderItemRepository.GetAllOrderItemsByOrderIdAsync(id);

			order.OrderItems = items;
			decimal totalPrice = 0;
			decimal totalTax = 0;
			foreach (OrderItem item in items)
			{
				var product = await _productRepository.GetProductAsync(item.ProductId);
				var category = await _categoryRepository.GetProductCategoryAsync(product.CategoryId);

				// totalTax += product.Price * category.Tax.Percentage * item.Quantity / 100;
				totalPrice += product.Price * item.Quantity;
			}

			return OrderMapper.ToDto(order);
		}

		public async Task<OrderResponseDto> UpdateOrderAsync(Guid id, OrderUpdateDto order)
		{
			Order original = await _repository.GetOrderAsync(id);

			Order updated = await _repository.UpdateOrderAsync(id, OrderMapper.FromDto(order, original.Id, original.BusinessId, original.Status, original.CreatedAt));

			return OrderMapper.ToDto(updated);
		}
	}
}
