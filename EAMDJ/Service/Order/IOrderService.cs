using EAMDJ.Dto.OrderDto;

namespace EAMDJ.Service.OrderService
{
	public interface IOrderService
	{
		Task<OrderResponseDto> GetOrderAsync(Guid id);
		Task<IEnumerable<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId);
		Task<OrderResponseDto> UpdateOrderAsync(Guid id, OrderUpdateDto order);
		Task DeleteOrderAsync(Guid id);
		Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto order);
	}
}
