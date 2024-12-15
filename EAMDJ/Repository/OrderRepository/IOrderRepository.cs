using EAMDJ.Model;

namespace EAMDJ.Repository.OrderRepository
{
	public interface IOrderRepository
	{
		Task<Order> GetOrderAsync(Guid id);
		Task<IEnumerable<Order>> GetAllOrdersByBusinessIdAsync(Guid businessId);
		Task<Order> UpdateOrderAsync(Guid id, Order order, Order original);
		Task DeleteOrderAsync(Guid id);
		Task<Order> CreateOrderAsync(Order order);

	}
}
