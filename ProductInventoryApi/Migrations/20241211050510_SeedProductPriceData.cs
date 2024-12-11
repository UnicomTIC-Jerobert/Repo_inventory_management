using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductPriceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.UpdateData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductPriceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 11, 5, 5, 9, 554, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.InsertData(
                table: "ProductPrices",
                columns: new[] { "Id", "DateSet", "Price", "ProductId" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600m, 1 });

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 12, 11, 5, 5, 9, 553, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "ProductStocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 12, 11, 5, 5, 9, 554, DateTimeKind.Utc).AddTicks(267));

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id");
        }
    }
}
