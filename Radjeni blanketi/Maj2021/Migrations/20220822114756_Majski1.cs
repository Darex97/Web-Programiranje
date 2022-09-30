using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Majski1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabrika",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrika", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Silosi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    TrenutnaPopunjenost = table.Column<int>(type: "int", nullable: false),
                    MojafabrikaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silosi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Silosi_Fabrika_MojafabrikaID",
                        column: x => x.MojafabrikaID,
                        principalTable: "Fabrika",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Silosi_MojafabrikaID",
                table: "Silosi",
                column: "MojafabrikaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Silosi");

            migrationBuilder.DropTable(
                name: "Fabrika");
        }
    }
}
