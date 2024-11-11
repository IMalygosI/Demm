using System;
using System.Collections.Generic;
using MasterPaulTestDemka.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPaulTestDemka.Context;

public partial class DimaBaseContext : DbContext
{
    public DimaBaseContext()
    {
    }

    public DimaBaseContext(DbContextOptions<DimaBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=dima_base;Username=dima;Password=dima");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("material_pk");

            entity.ToTable("Material_Type", "MasterPaul");

            entity.Property(e => e.IdMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_Material");
            entity.Property(e => e.MaterialScrapPercentage).HasColumnName("Material_Scrap_Percentage");
            entity.Property(e => e.TypeMaterial)
                .HasColumnType("character varying")
                .HasColumnName("Type_Material");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartners).HasName("partners_pk");

            entity.ToTable("Partners", "MasterPaul");

            entity.Property(e => e.IdPartners)
                .ValueGeneratedNever()
                .HasColumnName("id_Partners");
            entity.Property(e => e.Director).HasColumnType("character varying");
            entity.Property(e => e.Inn).HasColumnName("INN");
            entity.Property(e => e.PartnerEmail)
                .HasColumnType("character varying")
                .HasColumnName("Partner_Email");
            entity.Property(e => e.PartnerPhone).HasColumnName("Partner_Phone");
            entity.Property(e => e.PartnerSLegalAddress).HasColumnName("Partner's_Legal_Address");
            entity.Property(e => e.PartnersName)
                .HasColumnType("character varying")
                .HasColumnName("Partners_Name");
            entity.Property(e => e.PartnersType)
                .HasColumnType("character varying")
                .HasColumnName("Partners_Type");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.IdPartnerProducts).HasName("partner_products_pk");

            entity.ToTable("Partner_Products", "MasterPaul");

            entity.Property(e => e.IdPartnerProducts)
                .ValueGeneratedNever()
                .HasColumnName("id_Partner_Products");
            entity.Property(e => e.DateOfSale).HasColumnName("Date_Of_Sale");
            entity.Property(e => e.PartnerName).HasColumnName("Partner_Name");
            entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");

            entity.HasOne(d => d.PartnerNameNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_partners_fk");

            entity.HasOne(d => d.ProductsNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_products_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProducts).HasName("products_pk");

            entity.ToTable("Products", "MasterPaul");

            entity.Property(e => e.IdProducts)
                .ValueGeneratedNever()
                .HasColumnName("id_Products");
            entity.Property(e => e.MinimumCostForAPartner).HasColumnName("Minimum_Cost_For_A_Partner");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("Product_Name");
            entity.Property(e => e.TypeProducts).HasColumnName("Type_Products");

            entity.HasOne(d => d.TypeProductsNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_product_type_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdTypeProduct).HasName("product_type_pk");

            entity.ToTable("Product_Type", "MasterPaul");

            entity.Property(e => e.IdTypeProduct)
                .ValueGeneratedNever()
                .HasColumnName("id_Type_Product");
            entity.Property(e => e.ProductTypeFactor).HasColumnName("Product_Type_Factor");
            entity.Property(e => e.TypeProduct)
                .HasColumnType("character varying")
                .HasColumnName("Type_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
