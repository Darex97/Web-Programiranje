using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Jan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kategorija",
                table: "Filmovi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategorija",
                table: "Filmovi");
        }
    }
}
