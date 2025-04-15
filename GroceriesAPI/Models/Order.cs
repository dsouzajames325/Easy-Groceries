namespace GroceriesAPI.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public decimal TotalAmount { get; set; }
        public bool HasLoyaltyMembership { get; set; }
    }

}
