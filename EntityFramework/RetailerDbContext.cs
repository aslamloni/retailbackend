using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class RetailerDbContext : DbContext
    {
        public RetailerDbContext(DbContextOptions<RetailerDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Bills> Bill { get; set; }
        public DbSet<ItemPurchaseDetails> ItemPurchaseDetails { get; set; }
    }
}
