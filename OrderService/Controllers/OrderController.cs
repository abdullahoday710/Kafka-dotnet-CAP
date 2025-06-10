using Common;
using Common.Messages;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace KafkaCAPPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ICapPublisher publisher;
        public OrderController(ICapPublisher capPublisher)
        {
            publisher = capPublisher;
        }

        [HttpGet("PublishMessage")]
        public async Task<IActionResult> PublishMessage()
        {
            OrderCreatedMessage message = new OrderCreatedMessage {OrderID = 1, BillingAddress = "221B Baker Street", BuyerName = "Sherlock Holmes", ProductName = "Magnifying glass" };

            await publisher.PublishAsync(TopicNames.OrderCreated, message);
            return Ok("Message published!");
        }
    }
}
