using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public class OrderCreatedMessage
    {
        public required long OrderID { get; set; }
        public required string ProductName { get; set; }
        public required string BuyerName { get; set; }
        public required string BillingAddress { get; set; }
    }
}
