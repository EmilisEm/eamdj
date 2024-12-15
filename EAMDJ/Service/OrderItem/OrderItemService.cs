using EAMDJ.Dto.OrderItemDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.OrderItemRepository;
using EAMDJ.Repository.ProductModifierRepository;

namespace EAMDJ.Service.OrderItemService

{
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemRepository _repository;
		private readonly IProductModifierRepository _productModifierRepository;

		public OrderItemService(IOrderItemRepository repository, IProductModifierRepository productModifierRepository)
		{
			_repository = repository;
			_productModifierRepository = productModifierRepository;
		}

		public async Task<OrderItemResponseDto> CreateOrderItemAsync(OrderItemCreateDto order)
		{
			OrderItem mapped = OrderItemMapper.FromDto(order);
			if (order.ModifierIds == null)
			{
				throw new ArgumentException("Order item cannot be created as ModifierIds is null. Pass empty array [] for no modifiers");
			}
			mapped.ProductModifiers = await _productModifierRepository.GetAllByIdListAsync(order.ModifierIds);

			foreach (var modifier in mapped.ProductModifiers)
			{
				if (!modifier.OrderItems.Contains(mapped))
				{
					modifier.OrderItems.Add(mapped);
				}
			}
			OrderItem created = await _repository.CreateOrderItemAsync(mapped);

			return OrderItemMapper.ToDto(await _repository.GetOrderItemAsync(created.Id));


		}

		public async Task DeleteOrderItemAsync(Guid id)
		{
			await _repository.DeleteOrderItemAsync(id);
		}

		public async Task<IEnumerable<OrderItemResponseDto>> GetAllOrderItemsByOrderIdAsync(Guid orderId)
		{
			IEnumerable<OrderItem> orderes = await _repository.GetAllOrderItemsByOrderIdAsync(orderId);

			return orderes.Select(OrderItemMapper.ToDto);
		}

		public async Task<OrderItemResponseDto> GetOrderItemAsync(Guid id)
		{
			OrderItem order = await _repository.GetOrderItemAsync(id);

			return OrderItemMapper.ToDto(order);
		}

		public async Task<OrderItemResponseDto> UpdateOrderItemAsync(Guid id, OrderItemUpdateDto order)
		{
			OrderItem original = await _repository.GetOrderItemAsync(id);
			OrderItem mapped = OrderItemMapper.FromDto(order, original);
			if (order.ModifierIds == null)
			{
				throw new ArgumentException("Order item cannot be created as ModifierIds is null. Pass empty array [] for no modifiers");
			}
			mapped.ProductModifiers = await _productModifierRepository.GetAllByIdListAsync(order.ModifierIds);

			foreach (var modifier in mapped.ProductModifiers)
			{
				if (!modifier.OrderItems.Contains(mapped))
				{
					modifier.OrderItems.Add(mapped);
				}
			}
			OrderItem updated = await _repository.UpdateOrderItemAsync(id, mapped, original);

			return OrderItemMapper.ToDto(updated);
		}
	}
}
