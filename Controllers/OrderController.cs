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
            await publisher.PublishAsync("sample.message", new { Text = "Hello from CAP Kafka!" });
            return Ok("Message published!");
        }
    }
}
