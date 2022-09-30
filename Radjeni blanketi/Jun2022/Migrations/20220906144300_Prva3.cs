using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Prva3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Automobili",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Automobili",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Automobili");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Automobili");
        }
    }
}
