using System.ComponentModel.DataAnnotations;

namespace BillingService.Entities
{
    public class BillEntity
    {
        [Key]
        public long ID { get; set; }
        public long OrderID { get; set; }
        public required string BillingAddress { get; set; }
        public bool IsPaid { get; set; }
    }
}
