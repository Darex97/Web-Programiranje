using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class jun2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pretraga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Podrucje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cvet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stablo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPretrage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pretraga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdavnicaeBiljaka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdavnicaeBiljaka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CveceUProdavnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Podrucje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cvet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stablo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrPronadjenih = table.Column<int>(type: "int", nullable: false),
                    ProdavnicaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CveceUProdavnici", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CveceUProdavnici_ProdavnicaeBiljaka_ProdavnicaID",
                        column: x => x.ProdavnicaID,
                        principalTable: "ProdavnicaeBiljaka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CveceUProdavnici_ProdavnicaID",
                table: "CveceUProdavnici",
                column: "ProdavnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CveceUProdavnici");

            migrationBuilder.DropTable(
                name: "Pretraga");

            migrationBuilder.DropTable(
                name: "ProdavnicaeBiljaka");
        }
    }
}
