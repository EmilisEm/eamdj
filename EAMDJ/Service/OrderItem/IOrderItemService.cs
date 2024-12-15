using EAMDJ.Dto.OrderItemDto;

namespace EAMDJ.Service.OrderItemService
{
	public interface IOrderItemService
	{
		Task<OrderItemResponseDto> GetOrderItemAsync(Guid id);
		Task<IEnumerable<OrderItemResponseDto>> GetAllOrderItemsByOrderIdAsync(Guid orderId);
		Task<OrderItemResponseDto> UpdateOrderItemAsync(Guid id, OrderItemUpdateDto order);
		Task DeleteOrderItemAsync(Guid id);
		Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemCreateDto order);
	}
}
