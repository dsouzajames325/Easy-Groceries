using GroceriesAPI.Interfaces;
using GroceriesAPI.Models;

namespace GroceriesAPI.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(List<int> productIds, bool includeLoyaltyMembership)
        {
            var products = await _productRepository.GetAllProductsAsync();
            var orderLines = new List<OrderLine>();
            decimal totalAmount = 0;

            foreach (var productId in productIds)
            {
                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    var orderLine = new OrderLine { Product = product, Quantity = 1 }; // Simplified for now with quantity 1
                    orderLines.Add(orderLine);
                    totalAmount += orderLine.Total;
                }
            }

            if (includeLoyaltyMembership)
            {
                var loyaltyProduct = products.FirstOrDefault(p => p.IsLoyaltyMembership);
                if (loyaltyProduct != null)
                {
                    var orderLine = new OrderLine { Product = loyaltyProduct, Quantity = 1 };
                    orderLines.Add(orderLine);
                    totalAmount += orderLine.Total;

                    // Apply 20% discount
                    totalAmount *= 0.8M;
                }
            }

            var order = new Order
            {
                OrderNumber = new Random().Next(100000, 999999), // Generate a random order number
                CustomerId = 35496,
                OrderLines = orderLines,
                TotalAmount = totalAmount,
                HasLoyaltyMembership = includeLoyaltyMembership
            };

            await _orderRepository.SaveOrderAsync(order);

            return order;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();

        }
    }
}
