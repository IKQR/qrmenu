using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class RestaurantDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Restaurants");
        }
    }
}
