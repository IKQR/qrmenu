using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class Groups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "DishesGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DishesGroups_RestaurantId",
                table: "DishesGroups",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesGroups_Restaurants_RestaurantId",
                table: "DishesGroups",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesGroups_Restaurants_RestaurantId",
                table: "DishesGroups");

            migrationBuilder.DropIndex(
                name: "IX_DishesGroups_RestaurantId",
                table: "DishesGroups");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "DishesGroups");
        }
    }
}
