using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Jan22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProsecnaOcena",
                table: "Filmovi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProsecnaOcena",
                table: "Filmovi");
        }
    }
}
