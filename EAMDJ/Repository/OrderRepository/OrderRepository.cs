using EAMDJ.Context;
using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Repository.OrderRepository
{
	public class OrderRepository : IOrderRepository
	{
        private readonly ServiceAppContext _context;

        public OrderRepository(ServiceAppContext context) {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order business) {
            Guid id = Guid.NewGuid();

            _context.Order.Add(business);
            await _context.SaveChangesAsync();

            return business;
        }

        public async Task DeleteOrderAsync(Guid id) {
            var business = await _context.Order.FindAsync(id) ?? throw new ArgumentException("Order not found");
            _context.Order.Remove(business);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(Guid id) {
            var business = await _context.Order.FindAsync(id);

            if (business == null) {
                throw new ArgumentException("Order not found");
            }

            return business;
        }

        public async Task<Order> UpdateOrderAsync(Guid id, Order business) {
            if (id != business.Id) {
                throw new ArgumentException("Order not found");
            }

            _context.Entry(business).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!OrderExists(id)) {
                    throw new ArgumentException("Order not found");
                }
                else {
                    throw;
                }
            }

            return business;
        }

        private bool OrderExists(Guid id) {
            return _context.Order.Any(e => e.Id == id);
        }
    }

}
