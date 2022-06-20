using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class NullableGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Dishes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes",
                column: "GroupId",
                principalTable: "DishesGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes",
                column: "GroupId",
                principalTable: "DishesGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
