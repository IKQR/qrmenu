using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class IngredientRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RestaurantId",
                table: "Ingredients",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Restaurants_RestaurantId",
                table: "Ingredients",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Restaurants_RestaurantId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RestaurantId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Ingredients");
        }
    }
}
