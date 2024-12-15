using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.OrderItemRepository
{
	public class OrderItemRepository : IOrderItemRepository
	{
		private readonly ServiceAppContext _context;

		public OrderItemRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
		{
			_context.OrderItem.Add(orderItem);
			await _context.SaveChangesAsync();

			return orderItem;
		}

		public async Task DeleteOrderItemAsync(Guid id)
		{
			var orderItem = await _context.OrderItem.FindAsync(id) ?? throw new ArgumentException("Order item not found");
			_context.OrderItem.Remove(orderItem);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<OrderItem>> GetAllOrderItemsByOrderIdAsync(Guid orderId)
		{
			return await _context.OrderItem.Include(it => it.ProductModifiers).Include(it => it.Product).Where(it => it.OrderId.Equals(orderId)).ToListAsync();
		}

		public async Task<OrderItem> GetOrderItemAsync(Guid id)
		{
			OrderItem orderItem = await _context.OrderItem.Include(it => it.Product).Include(it => it.ProductModifiers).FirstAsync(it => it.Id == id);

			if (orderItem == null)
			{
				throw new ArgumentException("OrderItem not found");
			}

			return orderItem;
		}

		public async Task<OrderItem> UpdateOrderItemAsync(Guid id, OrderItem orderItem, OrderItem original)
		{
			if (id != orderItem.Id)
			{
				throw new ArgumentException("OrderItem not found");
			}

			_context.Entry(original).CurrentValues.SetValues(orderItem);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OrderItemExists(id))
				{
					throw new ArgumentException("OrderItem not found");
				}
				else
				{
					throw;
				}
			}

			return orderItem;
		}

		private bool OrderItemExists(Guid id)
		{
			return _context.OrderItem.Any(e => e.Id == id);
		}
	}
}
