using Common.Messages;
using Common;
using DotNetCore.CAP;
using BillingService.Entities;

namespace BillingService.Subscribers
{
    public class OrderCreateSubscriber : ICapSubscribe
    {
        private readonly BillingServiceDBContext _db;

        public OrderCreateSubscriber(BillingServiceDBContext db)
        {
            _db = db;
        }

        [CapSubscribe(TopicNames.OrderCreated)]
        public void HandleMessage(OrderCreatedMessage message)
        {
            BillEntity newBill = new BillEntity { BillingAddress = message.BillingAddress, IsPaid = false, OrderID = message.OrderID };
            
            _db.Add(newBill);
            _db.SaveChanges();

            Console.WriteLine("Added a new bill !");
        }
    }
}
