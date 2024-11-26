using EAMDJ.Dto;

namespace EAMDJ.Service.OrderService
{
	public interface IOrderService
	{
		Task<OrderDto> GetOrderAsync(Guid id);
		Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
		Task<OrderDto> UpdateOrderAsync(Guid id, OrderDto business);
		Task DeleteOrderAsync(Guid id);
		Task<OrderDto> CreateOrderAsync(OrderDto business);
	}
}
