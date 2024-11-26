using EAMDJ.Dto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.OrderItemRepository;

namespace EAMDJ.Service.OrderItemService

{
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemRepository _repository;

		public OrderItemService(IOrderItemRepository repository)
		{
			_repository = repository;
		}

		public async Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto order)
		{
			OrderItem created = await _repository.CreateOrderItemAsync(OrderItemMapper.FromDto(order));

			return OrderItemMapper.ToDto(created);


		}

		public async Task DeleteOrderItemAsync(Guid id)
		{
			await _repository.DeleteOrderItemAsync(id);
		}

		public async Task<IEnumerable<OrderItemDto>> GetAllOrderItemsByOrderIdAsync(Guid orderId)
		{
			IEnumerable<OrderItem> orderes = await _repository.GetAllOrderItemsByOrderIdAsync(orderId);

			return orderes.Select(OrderItemMapper.ToDto);
		}

		public async Task<OrderItemDto> GetOrderItemAsync(Guid id)
		{
			OrderItem order = await _repository.GetOrderItemAsync(id);

			return OrderItemMapper.ToDto(order);
		}

		public async Task<OrderItemDto> UpdateOrderItemAsync(Guid id, OrderItemDto order)
		{
			OrderItem updated = await _repository.UpdateOrderItemAsync(id, OrderItemMapper.FromDto(order));

			return OrderItemMapper.ToDto(updated);
		}
	}
}
