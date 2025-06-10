using Microsoft.EntityFrameworkCore;

namespace KafkaCAPPlayground
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //public DbSet<MessageRecord> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MessageRecord>().ToTable("Messages");
        }
    }
}
