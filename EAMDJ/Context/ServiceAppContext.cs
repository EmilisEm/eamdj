using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Context;

public class ServiceAppContext : DbContext {
    public DbSet<Business> Business { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<Tax> Tax { get; set; }
    public DbSet<User> User { get; set; }

    public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Configure relationship between Order and Business.
        modelBuilder.Entity<Order>()
            .HasOne<Business>(o => o.Business)
            .WithMany()
            .HasForeignKey(o => o.BusinessId);

        // Configure primary key for OrderItem and relationships between OrderItem and Order, Product. 
        modelBuilder.Entity<OrderItem>()
            .HasKey(o => new { o.OrderId, o.ProductId });
        modelBuilder.Entity<OrderItem>()
            .HasOne<Order>(o => o.Order)
            .WithMany()
            .HasForeignKey(o => o.OrderId);
        modelBuilder.Entity<OrderItem>()
            .HasOne<Product>(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId);

        // Configure relationship between Discount and Product.
        modelBuilder.Entity<Discount>()
            .HasOne<Product>(d => d.Product)
            .WithOne()
            .HasForeignKey<Discount>(d => d.ProductId);

        // Configure relationship between Product and ProductCategory.
        modelBuilder.Entity<Product>()
            .HasOne<ProductCategory>(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

        // Configure relationship between Tax and ProductCategory.
        modelBuilder.Entity<Tax>()
            .HasOne<ProductCategory>(t => t.ProductCategory)
            .WithMany()
            .HasForeignKey(t => t.ProductCategoryId);

        // Configure relationship between User and Business
        modelBuilder.Entity<User>()
            .HasOne<Business>(u => u.Business)
            .WithMany()
            .HasForeignKey(u => u.BusinessId);
    }
}