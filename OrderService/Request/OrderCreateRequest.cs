namespace OrderService.Request
{
    public class OrderCreateRequest
    {
        public required string ProductName { get; set; }
        public required string BillingAddress { get; set; }
        public required string BuyerName { get; set; }
    }
}
