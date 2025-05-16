using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface IOrderRepository
    {
       public Task<List<Order>> GetOrders();

        public Task<List<Order>> GetOrdersByUser(int userID);
        public ValueTask<Order?> GetOrderById(int orderId);
       public Task InsertOrder(Order order);
        
       public Task DeleteOrder(Order order);
       public Task UpdateOrder(Order order);
      
    }
}
