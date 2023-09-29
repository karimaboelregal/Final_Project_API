using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Data.Context
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        //public DataContext() 
        //{

        //}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=TestDB7;trusted_connection=true;TrustServerCertificate=true;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<OrderDetails>().HasKey(OrderDetails => new { OrderDetails.OrderId, OrderDetails.ProductId });
            builder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("money");
            builder.Entity<OrderDetails>().Property(od => od.UnitPrice).HasColumnType("money");
            builder.Entity<Product>().Property(p => p.UnitPrice).HasColumnType("money");
            builder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);


            base.OnModelCreating(builder);
        }
        
    }
}
