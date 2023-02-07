using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class table_porteurse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Traveller_PassportNumber",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Traveller_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Traveller");

            migrationBuilder.DropColumn(
                name: "Passfirstname",
                table: "Traveller");

            migrationBuilder.DropColumn(
                name: "TelNumber",
                table: "Traveller");

            migrationBuilder.RenameColumn(
                name: "Passlastname",
                table: "Traveller",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Traveller",
                newName: "HealthInformation");

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Passfirstname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Passlastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassportNumber);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "date", nullable: false),
                    TicketFK = table.Column<int>(type: "int", nullable: false),
                    PassengerFK = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.PassengerFK, x.TicketFK, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Passengers_PassengerFK",
                        column: x => x.PassengerFK,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets_TicketFK",
                        column: x => x.TicketFK,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketFK",
                table: "Reservations",
                column: "TicketFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Passengers_PassportNumber",
                table: "Staff",
                column: "PassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Traveller_Passengers_PassportNumber",
                table: "Traveller",
                column: "PassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_volsVoyageurs_Passengers_PassengersPassportNumber",
                table: "volsVoyageurs",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Passengers_PassportNumber",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Traveller_Passengers_PassportNumber",
                table: "Traveller");

            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Passengers_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Traveller",
                newName: "Passlastname");

            migrationBuilder.RenameColumn(
                name: "HealthInformation",
                table: "Traveller",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Traveller",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Passfirstname",
                table: "Traveller",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TelNumber",
                table: "Traveller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Traveller_PassportNumber",
                table: "Staff",
                column: "PassportNumber",
                principalTable: "Traveller",
                principalColumn: "PassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_volsVoyageurs_Traveller_PassengersPassportNumber",
                table: "volsVoyageurs",
                column: "PassengersPassportNumber",
                principalTable: "Traveller",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
