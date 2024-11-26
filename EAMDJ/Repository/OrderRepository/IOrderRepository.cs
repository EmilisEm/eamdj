using EAMDJ.Model;

namespace EAMDJ.Repository.OrderRepository
{
	public interface IOrderRepository
	{
		Task<Order> GetOrderAsync(Guid id);
		Task<IEnumerable<Order>> GetAllOrdersAsync();
		Task<Order> UpdateOrderAsync(Guid id, Order order);
		Task DeleteOrderAsync(Guid id);
		Task<Order> CreateOrderAsync(Order order);

	}
}
