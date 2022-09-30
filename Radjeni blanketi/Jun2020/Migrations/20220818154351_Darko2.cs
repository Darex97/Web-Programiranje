using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class Darko2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igraci_Mecevi_MecID",
                table: "Igraci");

            migrationBuilder.RenameColumn(
                name: "MecID",
                table: "Igraci",
                newName: "MecNaKojiUcestvujuID");

            migrationBuilder.RenameIndex(
                name: "IX_Igraci_MecID",
                table: "Igraci",
                newName: "IX_Igraci_MecNaKojiUcestvujuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Igraci_Mecevi_MecNaKojiUcestvujuID",
                table: "Igraci",
                column: "MecNaKojiUcestvujuID",
                principalTable: "Mecevi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igraci_Mecevi_MecNaKojiUcestvujuID",
                table: "Igraci");

            migrationBuilder.RenameColumn(
                name: "MecNaKojiUcestvujuID",
                table: "Igraci",
                newName: "MecID");

            migrationBuilder.RenameIndex(
                name: "IX_Igraci_MecNaKojiUcestvujuID",
                table: "Igraci",
                newName: "IX_Igraci_MecID");

            migrationBuilder.AddForeignKey(
                name: "FK_Igraci_Mecevi_MecID",
                table: "Igraci",
                column: "MecID",
                principalTable: "Mecevi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
