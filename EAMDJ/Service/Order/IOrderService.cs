using EAMDJ.Dto.OrderDto;
using EAMDJ.Dto.Shared;
using EAMDJ.Model;

namespace EAMDJ.Service.OrderService
{
	public interface IOrderService
	{
		Task<OrderResponseDto> GetOrderAsync(Guid id);
		Task<IEnumerable<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId);
		Task<PaginatedResult<OrderResponseDto>> GetAllOrdersByBusinessIdAsync(Guid businessId, int page, int pageSize);
		Task<OrderResponseDto> UpdateOrderAsync(Guid id, OrderUpdateDto order);
		Task DeleteOrderAsync(Guid id);
		Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto order);
		Task<OrderResponseDto> PaySumForOrder(Guid id, decimal sum);
	}
}
