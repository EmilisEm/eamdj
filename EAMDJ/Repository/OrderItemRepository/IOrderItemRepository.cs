using EAMDJ.Model;

namespace EAMDJ.Repository.OrderItemRepository
{
	public interface IOrderItemRepository
	{
		Task<OrderItem> GetOrderItemAsync(Guid id);
		Task<IEnumerable<OrderItem>> GetAllOrderItemsByOrderIdAsync(Guid orderId);
		Task<OrderItem> UpdateOrderItemAsync(Guid id, OrderItem orderItem);
		Task DeleteOrderItemAsync(Guid id);
		Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);

	}
}
