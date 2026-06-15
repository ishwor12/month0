using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcCore.Models;

namespace MvcCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
        public DbSet<SalesOrderItem> SalesOrderItems => Set<SalesOrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product → Category (restrict delete, don't cascade)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → Supplier
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalesOrderItem → SalesOrder
            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(i => i.SalesOrder)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.SalesOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // SalesOrderItem → Product (restrict, we don't want product deletes wiping history)
            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(i => i.Product)
                .WithMany(p => p.SalesOrderItems)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            // Decimal precision
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SalesOrderItem>()
                .Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // SKU unique
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();

        }
    }
}
