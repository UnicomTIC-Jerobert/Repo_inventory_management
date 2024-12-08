using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedInvoiceItemWithProductPriceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedProductPrice",
                table: "InvoiceItems",
                newName: "sellingPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductPriceId",
                table: "InvoiceItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductPriceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 8, 5, 46, 57, 745, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 12, 8, 5, 46, 57, 745, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 12, 8, 5, 46, 57, 745, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "sellingPrice",
                table: "InvoiceItems",
                newName: "UpdatedProductPrice");

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 1, 7, 19, 36, 608, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 12, 1, 7, 19, 36, 607, DateTimeKind.Utc).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 12, 1, 7, 19, 36, 607, DateTimeKind.Utc).AddTicks(8989));
        }
    }
}
