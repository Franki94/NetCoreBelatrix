using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_products");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasColumnName("product_name")
                .HasMaxLength(50);

            builder.Property(e => e.SupplierId)
                .HasColumnName("supplier_id");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price");

            builder.Property(e => e.Package)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("package");

            builder.Property(e => e.IsDiscontinued)
                .HasColumnName("is_discontinued");

            builder.HasOne(e => e.SupplierNavigation)
                .WithMany(e => e.ProductsNavigation)
                .HasForeignKey(e => e.SupplierId)
                .HasConstraintName("FK_product_suppliers");

            builder.HasIndex(e => e.ProductName)
              .HasName("product_name_idx");

            builder.HasIndex(e => e.SupplierId)
                .HasName("product_supplier_id_idx");
        }
    }
}
