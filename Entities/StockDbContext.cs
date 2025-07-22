using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class StockDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Seller>? Sellers { get; set; }
        public DbSet<SalesRecord>? SalesRecords { get; set; }
        public StockDbContext(DbContextOptions options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().ToTable(nameof(Seller));
            modelBuilder.Entity<SalesRecord>().ToTable(nameof(SalesRecord));
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<Category>().ToTable(nameof(Category));


            modelBuilder.Entity<Product>().
                HasIndex(p => p.ProductName).
                IsUnique();
        }
    }
}
