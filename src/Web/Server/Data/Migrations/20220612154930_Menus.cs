using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class Menus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliate_Menu_IndividualMenuId",
                table: "Affiliate");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Menu_SpecialMenusId",
                table: "DishMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurants_RestaurantId",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menus",
                newName: "IX_Menus_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliate_Menus_IndividualMenuId",
                table: "Affiliate",
                column: "IndividualMenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Menus_SpecialMenusId",
                table: "DishMenu",
                column: "SpecialMenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliate_Menus_IndividualMenuId",
                table: "Affiliate");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Menus_SpecialMenusId",
                table: "DishMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menu",
                newName: "IX_Menu_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliate_Menu_IndividualMenuId",
                table: "Affiliate",
                column: "IndividualMenuId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Menu_SpecialMenusId",
                table: "DishMenu",
                column: "SpecialMenusId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurants_RestaurantId",
                table: "Menu",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
