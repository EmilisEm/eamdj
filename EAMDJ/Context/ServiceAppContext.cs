﻿using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Context;

public class ServiceAppContext : DbContext
{
	public DbSet<Business> Business { get; set; }
	public DbSet<Order> Order { get; set; }
	public DbSet<OrderItem> OrderItem { get; set; }
	public DbSet<Discount> Discount { get; set; }
	public DbSet<Product> Product { get; set; }
	public DbSet<ProductCategory> ProductCategory { get; set; }
	public DbSet<ProductModifier> ProductModifier { get; set; }
	public DbSet<Tax> Tax { get; set; }
	public DbSet<User> User { get; set; }
	public DbSet<ServiceTime> ServiceTime { get; set; }
	public DbSet<Reservation> Reservation { get; set; }

	public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Order>()
			.HasOne<Business>(o => o.Business)
			.WithMany()
			.HasForeignKey(o => o.BusinessId);
		modelBuilder.Entity<Order>()
			.HasMany(o => o.OrderItems)
			.WithOne(i => i.Order)
			.HasForeignKey(i => i.OrderId)
			.IsRequired(false)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<OrderItem>()
			.HasKey(o => o.Id);
		modelBuilder.Entity<OrderItem>()
			.HasOne<Product>(o => o.Product)
			.WithMany()
			.HasForeignKey(o => o.ProductId);

		modelBuilder.Entity<Discount>()
			.HasOne<Product>(d => d.Product)
			.WithOne()
			.HasForeignKey<Discount>(d => d.ProductId);
		modelBuilder.Entity<Discount>()
			.HasOne(d => d.Business)
			.WithMany()
			.HasForeignKey(d => d.BusinessId);

		modelBuilder.Entity<Product>()
			.HasOne<ProductCategory>(p => p.Category)
			.WithMany(c => c.Products)
			.HasForeignKey(p => p.CategoryId);

		modelBuilder.Entity<ProductCategory>()
			.HasOne(t => t.Tax)
			.WithMany()
			.HasForeignKey(t => t.TaxId);

		modelBuilder.Entity<User>()
			.HasOne<Business>(u => u.Business)
			.WithMany()
			.HasForeignKey(u => u.BusinessId);

		modelBuilder.Entity<ProductModifier>()
			.HasOne(mod => mod.Product)
			.WithMany()
			.HasForeignKey(mod => mod.ProductId);

		modelBuilder.Entity<ServiceTime>()
			.HasOne(st => st.Product)
			.WithMany()
			.HasForeignKey(st => st.ServiceId)
			.IsRequired(true);

		modelBuilder.Entity<Reservation>()
			.HasOne(r => r.Employee)
			.WithMany()
			.HasForeignKey(r => r.EmployeeId);
		modelBuilder.Entity<Reservation>()
			.HasOne(r => r.ServiceTime)
			.WithMany()
			.HasForeignKey(r => r.ServiceTimeId);
		modelBuilder.Entity<Reservation>()
			.HasOne(r => r.Product)
			.WithMany()
			.HasForeignKey(r => r.ProductId);

		modelBuilder.Entity<ServiceTime>()
			.Property(st => st.Start)
			.HasColumnType("time");
		modelBuilder.Entity<ServiceTime>()
			.Property(st => st.End)
			.HasColumnType("time");
	}
}