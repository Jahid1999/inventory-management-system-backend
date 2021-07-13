using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemBackend.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Stock",
                newName: "Productid");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Product",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Product",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "Stock",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "ProductDescription");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
