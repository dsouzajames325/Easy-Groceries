using GroceriesAPI.Interfaces;
using GroceriesAPI.Models;
using GroceriesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceriesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IProductRepository _products;

        public OrderController(OrderService orderService, IProductRepository products)

        {
            _orderService = orderService;
            _products = products;
        }

        [HttpPost("create-order")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = await _orderService.CreateOrderAsync(request.ProductIds, request.IncludeLoyaltyMembership);
            return Ok(order);
        }

        [HttpGet("get-products")]
        public async Task<ActionResult<Product>> GetProducts()
        {            
            return Ok(await _orderService.GetProductsAsync());
        }
       
    }    
}
