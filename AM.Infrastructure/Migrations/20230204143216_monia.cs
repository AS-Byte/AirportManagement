using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class monia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Passengers_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Staff");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "PassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_volsVoyageurs_Staff_PassengersPassportNumber",
                table: "volsVoyageurs",
                column: "PassengersPassportNumber",
                principalTable: "Staff",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Staff_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_volsVoyageurs_Passengers_PassengersPassportNumber",
                table: "volsVoyageurs",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
