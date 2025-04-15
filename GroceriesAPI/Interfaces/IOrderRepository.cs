using GroceriesAPI.Models;

namespace GroceriesAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task SaveOrderAsync(Order order);
      
    }
}
