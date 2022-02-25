using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class kraj1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planeta_Galaksija_PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.DropIndex(
                name: "IX_Planeta_PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "TipRatnika",
                table: "Ratnik");

            migrationBuilder.DropColumn(
                name: "BrojRatnika",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "BrojPlaneta",
                table: "Galaksija");

            migrationBuilder.RenameColumn(
                name: "UGalaksiji",
                table: "Planeta",
                newName: "GalaksijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Planeta_GalaksijaID",
                table: "Planeta",
                column: "GalaksijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Planeta_Galaksija_GalaksijaID",
                table: "Planeta",
                column: "GalaksijaID",
                principalTable: "Galaksija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planeta_Galaksija_GalaksijaID",
                table: "Planeta");

            migrationBuilder.DropIndex(
                name: "IX_Planeta_GalaksijaID",
                table: "Planeta");

            migrationBuilder.RenameColumn(
                name: "GalaksijaID",
                table: "Planeta",
                newName: "UGalaksiji");

            migrationBuilder.AddColumn<string>(
                name: "TipRatnika",
                table: "Ratnik",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrojRatnika",
                table: "Planeta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetaUGalaksijiID",
                table: "Planeta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojPlaneta",
                table: "Galaksija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Planeta_PlanetaUGalaksijiID",
                table: "Planeta",
                column: "PlanetaUGalaksijiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Planeta_Galaksija_PlanetaUGalaksijiID",
                table: "Planeta",
                column: "PlanetaUGalaksijiID",
                principalTable: "Galaksija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
