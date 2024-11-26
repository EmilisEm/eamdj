using EAMDJ.Dto;
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

		public async Task<OrderDto> CreateOrderAsync(OrderDto business)
		{
			Order created = await _repository.CreateOrderAsync(OrderMapper.FromDto(business));

			return OrderMapper.ToDto(created);


		}

		public async Task DeleteOrderAsync(Guid id)
		{
			await _repository.DeleteOrderAsync(id);
		}

		public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
		{
			IEnumerable<Order> businesses = await _repository.GetAllOrdersAsync();

			return businesses.Select(OrderMapper.ToDto);
		}

		public async Task<OrderDto> GetOrderAsync(Guid id)
		{
			Order business = await _repository.GetOrderAsync(id);

			return OrderMapper.ToDto(business);
		}

		public async Task<OrderDto> UpdateOrderAsync(Guid id, OrderDto business)
		{
			Order updated = await _repository.UpdateOrderAsync(id, OrderMapper.FromDto(business));

			return OrderMapper.ToDto(updated);
		}
	}
}
