using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanetaPobedink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borba", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Galaksija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeGalaksije = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojPlaneta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galaksija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klasa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKlase = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Planeta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePlanete = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojRatnika = table.Column<int>(type: "int", nullable: false),
                    PlanetaUGalaksijiID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planeta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Planeta_Galaksija_PlanetaUGalaksijiID",
                        column: x => x.PlanetaUGalaksijiID,
                        principalTable: "Galaksija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BorbaPlaneta",
                columns: table => new
                {
                    BorbaPlaneteID = table.Column<int>(type: "int", nullable: false),
                    PlanetineBorbeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorbaPlaneta", x => new { x.BorbaPlaneteID, x.PlanetineBorbeID });
                    table.ForeignKey(
                        name: "FK_BorbaPlaneta_Borba_PlanetineBorbeID",
                        column: x => x.PlanetineBorbeID,
                        principalTable: "Borba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorbaPlaneta_Planeta_BorbaPlaneteID",
                        column: x => x.BorbaPlaneteID,
                        principalTable: "Planeta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Klasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Snaga = table.Column<int>(type: "int", nullable: false),
                    RatnikPlanetaID = table.Column<int>(type: "int", nullable: true),
                    RatnikovaKlasaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ratnik_Klasa_RatnikovaKlasaID",
                        column: x => x.RatnikovaKlasaID,
                        principalTable: "Klasa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratnik_Planeta_RatnikPlanetaID",
                        column: x => x.RatnikPlanetaID,
                        principalTable: "Planeta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorbaPlaneta_PlanetineBorbeID",
                table: "BorbaPlaneta",
                column: "PlanetineBorbeID");

            migrationBuilder.CreateIndex(
                name: "IX_Planeta_PlanetaUGalaksijiID",
                table: "Planeta",
                column: "PlanetaUGalaksijiID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_RatnikovaKlasaID",
                table: "Ratnik",
                column: "RatnikovaKlasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_RatnikPlanetaID",
                table: "Ratnik",
                column: "RatnikPlanetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorbaPlaneta");

            migrationBuilder.DropTable(
                name: "Ratnik");

            migrationBuilder.DropTable(
                name: "Borba");

            migrationBuilder.DropTable(
                name: "Klasa");

            migrationBuilder.DropTable(
                name: "Planeta");

            migrationBuilder.DropTable(
                name: "Galaksija");
        }
    }
}
