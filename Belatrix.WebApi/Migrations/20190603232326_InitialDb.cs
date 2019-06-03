using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(maxLength: 40, nullable: false),
                    contact_name = table.Column<string>(maxLength: 50, nullable: true),
                    contact_title = table.Column<string>(maxLength: 40, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    phone = table.Column<string>(maxLength: 40, nullable: true),
                    fax = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(nullable: false),
                    order_number = table.Column<string>(nullable: true),
                    customer_id = table.Column<int>(nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders__customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(nullable: true),
                    package = table.Column<string>(maxLength: 30, nullable: true),
                    is_discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_suppliers",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    queantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_item__orders",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item__products",
                        column: x => x.order_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "customer_name_idx",
                table: "customer",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "order_customer_id_idx",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "order_order_date_idx",
                table: "order",
                column: "order_date");

            migrationBuilder.CreateIndex(
                name: "order_item_order_id_idx",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "order_item_product_id_idx",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "product_name_idx",
                table: "product",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "product_supplier_id_idx",
                table: "product",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "supplier_name_idx",
                table: "supplier",
                column: "company_name");

            migrationBuilder.CreateIndex(
                name: "supplier_country_idx",
                table: "supplier",
                column: "country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
