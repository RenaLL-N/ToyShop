using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp
{
    public partial class DBToyShopContext : DbContext
    {
        public DBToyShopContext()
        {
        }

        public DBToyShopContext(DbContextOptions<DBToyShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Toys> Toys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MYPC\\SQLEXPRESS; Database=DBToyShop; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Employee_Shop");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ToyId).HasColumnName("ToyID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Offer_Manufacturers");

                entity.HasOne(d => d.Toy)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.ToyId)
                    .HasConstraintName("FK_Offer_Toys");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_Orders_Offer");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Orders_Shop");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Toys>(entity =>
            {
                entity.HasKey(e => e.ToyId);

                entity.Property(e => e.ToyId).HasColumnName("ToyID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
