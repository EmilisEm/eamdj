using EAMDJ.Dto.OrderItemDto;
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

		public async Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemCreateDto order)
		{
			OrderItem created = await _repository.CreateOrderItemAsync(OrderItemMapper.FromDto(order));

			return OrderItemMapper.ToDto(created);


		}

		public async Task DeleteOrderItemAsync(Guid id)
		{
			await _repository.DeleteOrderItemAsync(id);
		}

		public async Task<IEnumerable<OrderItemResponseDto>> GetAllOrderItemsByOrderIdAsync(Guid orderId)
		{
			IEnumerable<OrderItem> orderes = await _repository.GetAllOrderItemsByOrderIdAsync(orderId);

			return orderes.Select(OrderItemMapper.ToDto);
		}

		public async Task<OrderItemResponseDto> GetOrderItemAsync(Guid id)
		{
			OrderItem order = await _repository.GetOrderItemAsync(id);

			return OrderItemMapper.ToDto(order);
		}

		public async Task<OrderItemResponseDto> UpdateOrderItemAsync(Guid id, OrderItemUpdateDto order)
		{
			OrderItem original = await _repository.GetOrderItemAsync(id);
			OrderItem updated = await _repository.UpdateOrderItemAsync(id, OrderItemMapper.FromDto(order, original.Id, original.OrderId));

			return OrderItemMapper.ToDto(updated);
		}
	}
}
