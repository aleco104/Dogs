using System;
using System.Collections.Generic;
using ClassLibrary1.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Contexts;

public partial class ProductContext : DbContext
{
    public ProductContext()
    {
    }

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TargetAnimal> TargetAnimals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BAC235C0E");

            entity.HasIndex(e => e.CategoryName, "UQ__Categori__8517B2E0D8EA140D").IsUnique();

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufact__357E5CC1D3BCC20D");

            entity.HasIndex(e => e.ManufacturerName, "UQ__Manufact__3B9CDE2E274DD5C8").IsUnique();

            entity.Property(e => e.ManufacturerName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD626A68C5");

            entity.HasIndex(e => e.ProductName, "UQ__Products__DD5A978AF7D6ACB2").IsUnique();

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Animal).WithMany(p => p.Products)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__Products__Animal__5812160E");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__5629CD9C");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__Products__Manufa__571DF1D5");
        });

        modelBuilder.Entity<TargetAnimal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__TargetAn__A21A7307362C3C12");

            entity.HasIndex(e => e.AnimalName, "UQ__TargetAn__7E44376673E26769").IsUnique();

            entity.Property(e => e.AnimalName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
