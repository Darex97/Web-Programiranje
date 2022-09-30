using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Prva1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prodavnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPoslednjeProdaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdavnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Automobili_Prodavnice_ProdavnicaID",
                        column: x => x.ProdavnicaID,
                        principalTable: "Prodavnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_ProdavnicaID",
                table: "Automobili",
                column: "ProdavnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobili");

            migrationBuilder.DropTable(
                name: "Prodavnice");
        }
    }
}
