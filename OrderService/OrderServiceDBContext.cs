using Microsoft.EntityFrameworkCore;
using OrderService.Entities;

namespace KafkaCAPPlayground
{

    public class OrderServiceDBContext : DbContext
    {
        public OrderServiceDBContext(DbContextOptions<OrderServiceDBContext> options) : base(options)
        {
        }

        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MessageRecord>().ToTable("Messages");
        }
    }
}
