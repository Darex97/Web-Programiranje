using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planeta_Galaksija_PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratnik_Planeta_RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Ratnik_RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Planeta_PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.DropColumn(
                name: "PlanetaUGalaksijiID",
                table: "Planeta");

            migrationBuilder.AddColumn<int>(
                name: "PlanetaId",
                table: "Ratnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GalaksijaId",
                table: "Planeta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetaId1",
                table: "Borba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetaId2",
                table: "Borba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_PlanetaId",
                table: "Ratnik",
                column: "PlanetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Planeta_GalaksijaId",
                table: "Planeta",
                column: "GalaksijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planeta_Galaksija_GalaksijaId",
                table: "Planeta",
                column: "GalaksijaId",
                principalTable: "Galaksija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratnik_Planeta_PlanetaId",
                table: "Ratnik",
                column: "PlanetaId",
                principalTable: "Planeta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planeta_Galaksija_GalaksijaId",
                table: "Planeta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratnik_Planeta_PlanetaId",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Ratnik_PlanetaId",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Planeta_GalaksijaId",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "PlanetaId",
                table: "Ratnik");

            migrationBuilder.DropColumn(
                name: "GalaksijaId",
                table: "Planeta");

            migrationBuilder.DropColumn(
                name: "PlanetaId1",
                table: "Borba");

            migrationBuilder.DropColumn(
                name: "PlanetaId2",
                table: "Borba");

            migrationBuilder.AddColumn<int>(
                name: "RatnikPlanetaID",
                table: "Ratnik",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetaUGalaksijiID",
                table: "Planeta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_RatnikPlanetaID",
                table: "Ratnik",
                column: "RatnikPlanetaID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ratnik_Planeta_RatnikPlanetaID",
                table: "Ratnik",
                column: "RatnikPlanetaID",
                principalTable: "Planeta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
