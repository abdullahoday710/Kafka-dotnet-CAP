using System.ComponentModel.DataAnnotations;

namespace OrderService.Entities
{
    public class OrderEntity
    {
        [Key]
        public long ID { get; set; }

        public required string ProductName { get; set; }
        public required string BillingAddress { get; set; }
        public required string BuyerName { get; set; }
    }
}
