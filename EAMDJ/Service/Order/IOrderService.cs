using EAMDJ.Dto;

namespace EAMDJ.Service.OrderService
{
	public interface IOrderService
	{
		Task<OrderDto> GetOrderAsync(Guid id);
		Task<IEnumerable<OrderDto>> GetAllOrdersByBusinessIdAsync(Guid businessId);
		Task<OrderDto> UpdateOrderAsync(Guid id, OrderDto order);
		Task DeleteOrderAsync(Guid id);
		Task<OrderDto> CreateOrderAsync(OrderDto order);
	}
}
