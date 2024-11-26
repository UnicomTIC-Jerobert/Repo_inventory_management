using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class ForiegnKeyIssueSolvedAndDataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_ProductStocks_ProductStockId",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UpdatedStock",
                table: "ProductStocks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "StockUpdateDate",
                table: "ProductStocks",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "ProductStockId",
                table: "ProductPrices",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PriceEffectiveDate",
                table: "ProductPrices",
                newName: "DateSet");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrices_ProductStockId",
                table: "ProductPrices",
                newName: "IX_ProductPrices_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_Products_ProductId",
                table: "ProductPrices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_Products_ProductId",
                table: "ProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductStocks",
                newName: "UpdatedStock");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "ProductStocks",
                newName: "StockUpdateDate");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductPrices",
                newName: "ProductStockId");

            migrationBuilder.RenameColumn(
                name: "DateSet",
                table: "ProductPrices",
                newName: "PriceEffectiveDate");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                newName: "IX_ProductPrices_ProductStockId");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Products",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_ProductStocks_ProductStockId",
                table: "ProductPrices",
                column: "ProductStockId",
                principalTable: "ProductStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
