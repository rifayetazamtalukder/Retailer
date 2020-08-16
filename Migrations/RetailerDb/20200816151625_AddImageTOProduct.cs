using Microsoft.EntityFrameworkCore.Migrations;

namespace Retailer.Migrations.RetailerDb
{
    public partial class AddImageTOProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageName",
                table: "Products");
        }
    }
}
