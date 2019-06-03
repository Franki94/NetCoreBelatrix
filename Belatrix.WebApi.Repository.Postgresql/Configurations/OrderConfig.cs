using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(e => e.Id).HasName("PK_orders");           

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.OrderDate)
                .IsRequired()
                .HasColumnName("order_date");

            builder.Property(e => e.OrderNumber)
                .HasColumnName("order_number");

            builder.Property(e => e.CustomerId)
                .HasColumnName("customer_id");

            builder.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12,2)")
                .HasColumnName("total_amount");

            builder.HasOne(e => e.CustomerNavigation)
                .WithMany(e => e.OrdersNavigation)
                .HasForeignKey(e => e.CustomerId)
                .HasConstraintName("FK_orders__customer_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.CustomerId)
               .HasName("order_customer_id_idx");

            builder.HasIndex(e => e.OrderDate)
                .HasName("order_order_date_idx");
        }
    }
}
