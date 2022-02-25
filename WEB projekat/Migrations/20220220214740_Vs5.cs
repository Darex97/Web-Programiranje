using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class Vs5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratnik_Planeta_RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Ratnik_RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.DropColumn(
                name: "RatnikPlanetaID",
                table: "Ratnik");

            migrationBuilder.RenameColumn(
                name: "SaPlanete",
                table: "Ratnik",
                newName: "PlanetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_PlanetaId",
                table: "Ratnik",
                column: "PlanetaId");

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
                name: "FK_Ratnik_Planeta_PlanetaId",
                table: "Ratnik");

            migrationBuilder.DropIndex(
                name: "IX_Ratnik_PlanetaId",
                table: "Ratnik");

            migrationBuilder.RenameColumn(
                name: "PlanetaId",
                table: "Ratnik",
                newName: "SaPlanete");

            migrationBuilder.AddColumn<int>(
                name: "RatnikPlanetaID",
                table: "Ratnik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_RatnikPlanetaID",
                table: "Ratnik",
                column: "RatnikPlanetaID");

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
