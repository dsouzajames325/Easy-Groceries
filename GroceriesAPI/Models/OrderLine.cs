namespace GroceriesAPI.Models
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Product.Price * Quantity;
    }
}
