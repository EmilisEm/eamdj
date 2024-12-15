using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.OrderRepository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ServiceAppContext _context;

		public OrderRepository(ServiceAppContext context)
		{
			_context = context;
		}

		public async Task<Order> CreateOrderAsync(Order orderItem)
		{
			_context.Order.Add(orderItem);
			await _context.SaveChangesAsync();

			return orderItem;
		}

		public async Task DeleteOrderAsync(Guid id)
		{
			var orderItem = await _context.Order.FindAsync(id) ?? throw new ArgumentException("Order not found");
			_context.Order.Remove(orderItem);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Order>> GetAllOrdersByBusinessIdAsync(Guid businessId)
		{
			return await _context.Order.Where(it => it.BusinessId.Equals(businessId)).Include(it => it.Discount).Include(it => it.OrderItems).ToListAsync();
		}

		public async Task<Order> GetOrderAsync(Guid id)
		{
			var orderItem = await _context.Order.Include(it => it.Discount).FirstAsync(it => it.Id == id);

			if (orderItem == null)
			{
				throw new ArgumentException("Order not found");
			}

			return orderItem;
		}

		public async Task<Order> UpdateOrderAsync(Guid id, Order orderItem, Order original)
		{
			if (id != orderItem.Id)
			{
				throw new ArgumentException("Order not found");
			}

			_context.Entry(original).CurrentValues.SetValues(orderItem);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OrderExists(id))
				{
					throw new ArgumentException("Order not found");
				}
				else
				{
					throw;
				}
			}

			return orderItem;
		}

		private bool OrderExists(Guid id)
		{
			return _context.Order.Any(e => e.Id == id);
		}
	}

}
