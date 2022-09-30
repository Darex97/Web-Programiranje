using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Grad1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeteoroloskiPodaci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    KolicinaPadavina = table.Column<int>(type: "int", nullable: false),
                    SuncaniDani = table.Column<int>(type: "int", nullable: false),
                    GradoviID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteoroloskiPodaci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeteoroloskiPodaci_Gradovi_GradoviID",
                        column: x => x.GradoviID,
                        principalTable: "Gradovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeteoroloskiPodaci_GradoviID",
                table: "MeteoroloskiPodaci",
                column: "GradoviID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeteoroloskiPodaci");

            migrationBuilder.DropTable(
                name: "Gradovi");
        }
    }
}
