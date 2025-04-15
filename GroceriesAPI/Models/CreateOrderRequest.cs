namespace GroceriesAPI.Models
{
    public class CreateOrderRequest
    {
        public List<int> ProductIds { get; set; }
        public bool IncludeLoyaltyMembership { get; set; }
    }
}
