using GroceriesAPI.Interfaces;
using GroceriesAPI.Models;

namespace GroceriesAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public Task SaveOrderAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {           
            return Task.FromResult(_orders);
        }
    }

}
