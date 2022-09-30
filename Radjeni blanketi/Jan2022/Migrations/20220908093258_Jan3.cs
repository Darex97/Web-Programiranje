using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Jan3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProsecnaOcena",
                table: "Filmovi",
                newName: "UkupnaOcena");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UkupnaOcena",
                table: "Filmovi",
                newName: "ProsecnaOcena");
        }
    }
}
