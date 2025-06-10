using Common.Messages;
using Common;
using DotNetCore.CAP;

namespace BillingService.Subscribers
{
    public class OrderCreateSubscriber : ICapSubscribe
    {
        [CapSubscribe(TopicNames.OrderCreated)]
        public void HandleMessage(OrderCreatedMessage message)
        {
            Console.WriteLine($"Received: {message.OrderID}");
        }
    }
}
