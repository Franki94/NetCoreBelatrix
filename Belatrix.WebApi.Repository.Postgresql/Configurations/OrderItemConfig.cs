using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.HasKey(e => e.Id)
                .HasName("PK_order_items");

            builder.Property(e => e.OrderId)                
                .HasColumnName("order_id");

            builder.Property(e => e.ProductId)                
                .HasColumnName("product_id");

            builder.Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(12,2)")
                .HasColumnName("unit_price");

            builder.Property(e => e.Quantity).IsRequired()
                .HasColumnName("queantity");

            builder.HasOne(e => e.OrderNavigation)
                .WithMany(e => e.OrderItemsNavigation)
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("FK_order_item__orders");

            builder.HasOne(e => e.ProductNavigation)
                .WithMany(e => e.OrderItemsNavigation)
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("FK_order_item__products");

            builder.HasIndex(e => e.OrderId)
              .HasName("order_item_order_id_idx");

            builder.HasIndex(e => e.ProductId)
                .HasName("order_item_product_id_idx");
        }
    }
}
