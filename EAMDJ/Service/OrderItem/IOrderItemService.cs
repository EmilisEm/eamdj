using EAMDJ.Dto;

namespace EAMDJ.Service.OrderItemService
{
	public interface IOrderItemService
	{
		Task<OrderItemDto> GetOrderItemAsync(Guid id);
		Task<IEnumerable<OrderItemDto>> GetAllOrderItemsByOrderIdAsync(Guid orderId);
		Task<OrderItemDto> UpdateOrderItemAsync(Guid id, OrderItemDto order);
		Task DeleteOrderItemAsync(Guid id);
		Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto order);
	}
}
