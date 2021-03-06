﻿// <auto-generated />
using System;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Migrations
{
    [DbContext(typeof(BelatrixDbContext))]
    [Migration("20190618180437_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Belatrix.WebApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.HasKey("Id")
                        .HasName("PK_customer");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("customer_name_idx");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderNumber")
                        .HasColumnName("order_number");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnName("total_amount")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id")
                        .HasName("PK_orders");

                    b.HasIndex("CustomerId")
                        .HasName("order_customer_id_idx");

                    b.HasIndex("OrderDate")
                        .HasName("order_order_date_idx");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id")
                        .HasName("PK_order_items");

                    b.HasIndex("OrderId")
                        .HasName("order_item_order_id_idx");

                    b.HasIndex("ProductId")
                        .HasName("order_item_product_id_idx");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnName("is_discontinued");

                    b.Property<string>("Package")
                        .HasColumnName("package")
                        .HasMaxLength(30);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierId")
                        .HasColumnName("supplier_id");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnName("unit_price");

                    b.HasKey("Id")
                        .HasName("PK_products");

                    b.HasIndex("ProductName")
                        .HasName("product_name_idx");

                    b.HasIndex("SupplierId")
                        .HasName("product_supplier_id_idx");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("company_name")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .HasColumnName("contact_name")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTitle")
                        .HasColumnName("contact_title")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("Fax")
                        .HasColumnName("fax")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(40);

                    b.HasKey("Id")
                        .HasName("PK_suppliers");

                    b.HasIndex("CompanyName")
                        .HasName("supplier_name_idx");

                    b.HasIndex("Country")
                        .HasName("supplier_country_idx");

                    b.ToTable("supplier");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Customer", "CustomerNavigation")
                        .WithMany("OrdersNavigation")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_orders__customer_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Order", "OrderNavigation")
                        .WithMany("OrderItemsNavigation")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_item__orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Belatrix.WebApi.Models.Product", "ProductNavigation")
                        .WithMany("OrderItemsNavigation")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_order_item__products")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Supplier", "SupplierNavigation")
                        .WithMany("ProductsNavigation")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_product_suppliers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
