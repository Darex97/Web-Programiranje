using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_projekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratnik_Klasa_RatnikovaKlasaID",
                table: "Ratnik");

            migrationBuilder.DropTable(
                name: "Klasa");

            migrationBuilder.DropIndex(
                name: "IX_Ratnik_RatnikovaKlasaID",
                table: "Ratnik");

            migrationBuilder.DropColumn(
                name: "RatnikovaKlasaID",
                table: "Ratnik");

            migrationBuilder.AddColumn<string>(
                name: "TipRatnika",
                table: "Ratnik",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipRatnika",
                table: "Ratnik");

            migrationBuilder.AddColumn<int>(
                name: "RatnikovaKlasaID",
                table: "Ratnik",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Ratnik_RatnikovaKlasaID",
                table: "Ratnik",
                column: "RatnikovaKlasaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratnik_Klasa_RatnikovaKlasaID",
                table: "Ratnik",
                column: "RatnikovaKlasaID",
                principalTable: "Klasa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
