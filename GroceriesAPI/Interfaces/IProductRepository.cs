using GroceriesAPI.Models;

namespace GroceriesAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
