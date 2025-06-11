using Common.Messages;
using Common;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {

        // Using DB context directly here because I am focusing on kafka and microservice architecture.
        // In a real world application I would use repository pattern instead.
        private BillingServiceDBContext _db;
        public BillController(BillingServiceDBContext db)
        {
            _db = db;
        }

        [HttpGet("GetAllBills")]
        public async Task<IActionResult> GetAllBills(int pageIndex, int pageSize)
        {
            var bills = await _db.Bills.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(bills);
        }
    }
}
