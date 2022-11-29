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

        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=OrderManagement74029;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productprice)
                    .HasColumnName("productprice")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Productquantity).HasColumnName("productquantity");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__custo__4BAC3F29");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__produ__4CA06362");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Customeremail)
                    .IsRequired()
                    .HasColumnName("customeremail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Customername)
                    .IsRequired()
                    .HasColumnName("customername")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Customerpassword)
                    .IsRequired()
                    .HasColumnName("customerpassword")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Stat)
                    .IsRequired()
                    .HasColumnName("stat")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__custo__52593CB8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__produ__534D60F1");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Addres)
                    .IsRequired()
                    .HasColumnName("addres")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("paymentMethod")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("decimal(13, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__customer__4F7CD00D");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imglinks)
                    .IsRequired()
                    .HasColumnName("imglinks")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Productdetail)
                    .IsRequired()
                    .HasColumnName("productdetail")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Productprice)
                    .HasColumnName("productprice")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Productquantity).HasColumnName("productquantity");
            });
        }
    }
}
