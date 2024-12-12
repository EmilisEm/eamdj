using EAMDJ.Dto.OrderDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.OrderRepository;

namespace EAMDJ.Service.OrderService

{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;

		public OrderService(IOrderRepository repository)
		{
			_repository = repository;
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
