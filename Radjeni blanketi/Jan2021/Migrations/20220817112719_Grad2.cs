using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Grad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazivMeseca",
                table: "MeteoroloskiPodaci",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivMeseca",
                table: "MeteoroloskiPodaci");
        }
    }
}
