using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.HasKey(e => e.Id).HasName("PK_suppliers");

            builder.Property(e => e.Id)
               .HasColumnName("id")
               .UseNpgsqlIdentityColumn();

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("company_name");

            builder.Property(e => e.ContactName)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("contact_name");

            builder.Property(e => e.ContactTitle)
                .IsRequired(false)
                .HasMaxLength(40)
                .HasColumnName("contact_title");

            builder.Property(e => e.City)
                .IsRequired(false)
                .HasMaxLength(40)
                .HasColumnName("city");

            builder.Property(e => e.Country)
                .IsRequired(false)
                .HasMaxLength(40)
                .HasColumnName("country");

            builder.Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(40)
                .HasColumnName("phone");

            builder.Property(e => e.Fax)
                .IsRequired(false)
                .HasMaxLength(30)
                .HasColumnName("fax");

            builder.HasIndex(e => e.CompanyName)
              .HasName("supplier_name_idx");

            builder.HasIndex(e => e.Country)
                .HasName("supplier_country_idx");
        }
    }
}
