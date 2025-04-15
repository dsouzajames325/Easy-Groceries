using GroceriesAPI.Interfaces;
using GroceriesAPI.Models;

namespace GroceriesAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Milk", Description = "The best of cows", Price = 2.00M },
        new Product { Id = 2, Name = "Bread", Description = "Easy toast", Price = 1.50M },
        new Product { Id = 3, Name = "Eggs", Description = "Wild chicken", Price = 3.00M },
        new Product { Id = 4, Name = "EasyGroceries Membership", Description = "Get 20% off on all orders", Price = 5.00M, IsLoyaltyMembership = true }
    };

        public Task<List<Product>> GetAllProductsAsync()
        {
            return Task.FromResult(_products);
        }
    }
}
