using BillingService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillingService
{
    public class BillingServiceDBContext : DbContext
    {
        public BillingServiceDBContext(DbContextOptions<BillingServiceDBContext> options) : base(options)
        {

        }

        public DbSet<BillEntity> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MessageRecord>().ToTable("Messages");
        }
    }
}
