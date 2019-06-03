using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(x => x.Id).HasName("PK_customer");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(40);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(40);

            builder.Property(x => x.City).IsRequired(false)
                .HasColumnName("city").HasMaxLength(40);

            builder.Property(x => x.Country).IsRequired(false)
               .HasColumnName("country").HasMaxLength(40);

            builder.Property(x => x.Phone).IsRequired(false)
               .HasColumnName("phone").HasMaxLength(20);

            builder.HasIndex(x => new { x.LastName, x.FirstName }).HasName("customer_name_idx");

        }
    }
}
