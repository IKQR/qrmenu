using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QRCodeMenu.Server.Data.Migrations
{
    public partial class DishesGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DishesGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_GroupId",
                table: "Dishes",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes",
                column: "GroupId",
                principalTable: "DishesGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishesGroups_GroupId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DishesGroups");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_GroupId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Dishes");
        }
    }
}
