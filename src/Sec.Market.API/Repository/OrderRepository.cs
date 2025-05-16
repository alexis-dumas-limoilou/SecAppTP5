using Sec.Market.API.Data;
using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Sec.Market.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public readonly MarketContext _context;

        public OrderRepository(MarketContext context)
        {
            _context = context;
        }
      
        public Task DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            return _context.SaveChangesAsync();
        }

        public ValueTask<Order?> GetOrderById(int orderId)
        {
          return _context.Orders.FindAsync(orderId);
        }
        
        public Task<List<Order>> GetOrders()
        {
            return _context.Orders.ToListAsync();
        }

        public Task<List<Order>> GetOrdersByUser(int userID)
        {
            return _context.Orders.Where(o=>o.UserId==userID).ToListAsync();
        }

        public Task InsertOrder(Order order)
        {
            _context.Orders.Add(order);
            return _context.SaveChangesAsync();
        }


        public Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            return _context.SaveChangesAsync();
        }

       
    }
}
