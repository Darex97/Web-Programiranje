using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Jan2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdukcijskeKuce",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdukcijskeKuce", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrOcena = table.Column<int>(type: "int", nullable: false),
                    ProdukcijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Filmovi_ProdukcijskeKuce_ProdukcijaID",
                        column: x => x.ProdukcijaID,
                        principalTable: "ProdukcijskeKuce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_ProdukcijaID",
                table: "Filmovi",
                column: "ProdukcijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmovi");

            migrationBuilder.DropTable(
                name: "ProdukcijskeKuce");
        }
    }
}
