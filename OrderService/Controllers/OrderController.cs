using Common;
using Common.Messages;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using OrderService.Request;

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

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderCreateRequest orderCreateRequest)
        {
            OrderCreatedMessage message = new OrderCreatedMessage {
                OrderID = 1,
                BillingAddress = orderCreateRequest.BillingAddress,
                BuyerName = orderCreateRequest.BuyerName,
                ProductName = orderCreateRequest.ProductName };

            await publisher.PublishAsync(TopicNames.OrderCreated, message);
            return Ok("Message published!");
        }
    }
}
