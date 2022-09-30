using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PlanetaId",
                table: "Ratnik",
                newName: "SaPlanete");

            migrationBuilder.RenameColumn(
                name: "GalaksijaId",
                table: "Planeta",
                newName: "UGalaksiji");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "SaPlanete",
                table: "Ratnik",
                newName: "PlanetaId");

            migrationBuilder.RenameColumn(
                name: "UGalaksiji",
                table: "Planeta",
                newName: "GalaksijaId");

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
    }
}
