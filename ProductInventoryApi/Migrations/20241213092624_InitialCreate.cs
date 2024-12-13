using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateSet = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductPriceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    sellingPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                        column: x => x.ProductPriceId,
                        principalTable: "ProductPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8bf1abda-9db6-4b49-8632-7903b5b520e0"), "Electronics items Desc", "Electronics" },
                    { new Guid("ab4f6cbc-7e7d-4747-83a2-e21cf19b5a02"), "Furniture items Desc", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Balance", "Date", "PaidAmount", "Total" },
                values: new object[] { new Guid("f83a54d2-0c5d-477b-844d-f672bf9d4f15"), 500m, new DateTime(2024, 12, 13, 9, 26, 23, 400, DateTimeKind.Utc).AddTicks(5467), 2500m, 3000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("158d8452-a8b6-4d3b-9c07-059894d5282e"), new Guid("ab4f6cbc-7e7d-4747-83a2-e21cf19b5a02"), "Dining Table", "Table" },
                    { new Guid("ba8466d2-ae2f-4e7e-ab05-9acde5c359a1"), new Guid("8bf1abda-9db6-4b49-8632-7903b5b520e0"), "Gaming Laptop", "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "ProductPrices",
                columns: new[] { "Id", "DateSet", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("13c536a6-dd25-42a0-ad8b-f5d2237d1b2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600m, new Guid("ba8466d2-ae2f-4e7e-ab05-9acde5c359a1") },
                    { new Guid("a12f75c5-99bf-4123-9d9e-4610ce6c0222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, new Guid("158d8452-a8b6-4d3b-9c07-059894d5282e") },
                    { new Guid("b8712890-b97c-4ef8-a636-bc84f20e5d9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m, new Guid("ba8466d2-ae2f-4e7e-ab05-9acde5c359a1") }
                });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "Id", "DateAdded", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4bc386f6-3ef8-4bbd-8e64-f1b89d8bc1ac"), new DateTime(2024, 12, 13, 9, 26, 23, 400, DateTimeKind.Utc).AddTicks(3874), new Guid("158d8452-a8b6-4d3b-9c07-059894d5282e"), 5 },
                    { new Guid("a2e67471-1df2-45b2-b434-f0a7a7900a08"), new DateTime(2024, 12, 13, 9, 26, 23, 400, DateTimeKind.Utc).AddTicks(3876), new Guid("158d8452-a8b6-4d3b-9c07-059894d5282e"), 10 },
                    { new Guid("cc92125e-3f94-40ef-8fbe-7e9b960c5e1d"), new DateTime(2024, 12, 13, 9, 26, 23, 400, DateTimeKind.Utc).AddTicks(3710), new Guid("ba8466d2-ae2f-4e7e-ab05-9acde5c359a1"), 10 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "InvoiceId", "ProductId", "ProductPriceId", "Qty", "sellingPrice" },
                values: new object[,]
                {
                    { new Guid("0a40b31e-5d82-497e-a3f4-0da50c0157d5"), new Guid("f83a54d2-0c5d-477b-844d-f672bf9d4f15"), new Guid("158d8452-a8b6-4d3b-9c07-059894d5282e"), new Guid("a12f75c5-99bf-4123-9d9e-4610ce6c0222"), 2, 1500m },
                    { new Guid("3c90a3f2-7b65-4e63-a0f9-0deea0b965ef"), new Guid("f83a54d2-0c5d-477b-844d-f672bf9d4f15"), new Guid("ba8466d2-ae2f-4e7e-ab05-9acde5c359a1"), new Guid("13c536a6-dd25-42a0-ad8b-f5d2237d1b2b"), 2, 1500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductId",
                table: "InvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_ProductId",
                table: "ProductStocks",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "ProductStocks");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
