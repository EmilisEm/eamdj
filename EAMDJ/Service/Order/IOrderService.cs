using EAMDJ.Dto.OrderDto;
using EAMDJ.Model;

namespace EAMDJ.Service.OrderService
{
	public interface IOrderService
	{
		Task<OrderResponseDto> GetOrderAsync(Guid id);
		Task<IEnumerable<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId);
		Task<OrderResponseDto> UpdateOrderAsync(Guid id, OrderUpdateDto order);
		Task<Order> UpdateOrderStatusAsync(Guid id, OrderStatus newStatus);
		Task DeleteOrderAsync(Guid id);
		Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto order);
	}
}
