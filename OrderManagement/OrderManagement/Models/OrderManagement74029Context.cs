using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrderManagement.Models
{
    public partial class OrderManagement74029Context : DbContext
    {
        public OrderManagement74029Context()
        {
        }

        public OrderManagement74029Context(DbContextOptions<OrderManagement74029Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerLogin> CustomerLogin { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=OrderManagement74029;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerLogin>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Orderdetails)
                    .HasColumnName("orderdetails")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Paymentmethod)
                    .HasColumnName("paymentmethod")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .HasColumnName("productname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Qunatity).HasColumnName("qunatity");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Productdetails)
                    .HasColumnName("productdetails")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Productname)
                    .HasColumnName("productname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Productprice)
                    .HasColumnName("productprice")
                    .HasColumnType("decimal(13, 2)");
            });
        }
    }
}
