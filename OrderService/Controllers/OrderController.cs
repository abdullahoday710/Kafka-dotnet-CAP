using Common;
using Common.Messages;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using OrderService.Entities;
using OrderService.Request;

namespace KafkaCAPPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ICapPublisher publisher;

        // Using DB context directly here because I am focusing on kafka and microservice architecture.
        // In a real world application I would use repository pattern instead.
        private readonly OrderServiceDBContext _db;
        public OrderController(ICapPublisher capPublisher, OrderServiceDBContext db)
        {
            publisher = capPublisher;
            _db = db;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderCreateRequest orderCreateRequest)
        {
            OrderEntity newOrder = new OrderEntity { BillingAddress = orderCreateRequest.BillingAddress, BuyerName = orderCreateRequest.BuyerName, ProductName = orderCreateRequest.ProductName };

            await _db.AddAsync(newOrder);
            await _db.SaveChangesAsync();

            OrderCreatedMessage message = new OrderCreatedMessage {
                OrderID = newOrder.ID,
                BillingAddress = orderCreateRequest.BillingAddress,
                BuyerName = orderCreateRequest.BuyerName,
                ProductName = orderCreateRequest.ProductName };

            await publisher.PublishAsync(TopicNames.OrderCreated, message);

            return Ok(new { order = newOrder, status = $"Order created and a message has been published to ({TopicNames.OrderCreated}) topic" });
        }
    }
}
