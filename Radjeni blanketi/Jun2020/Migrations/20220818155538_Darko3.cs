using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Darko3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Godina",
                table: "Mecevi");

            migrationBuilder.AddColumn<string>(
                name: "Datum",
                table: "Mecevi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Mecevi");

            migrationBuilder.AddColumn<int>(
                name: "Godina",
                table: "Mecevi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
