using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class souad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Staff_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Passfirstname",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Passlastname",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "TelNumber",
                table: "Staff");

            migrationBuilder.AlterColumn<float>(
                name: "Salary",
                table: "Staff",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Function",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmployementDate",
                table: "Staff",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Traveller",
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
                    table.PrimaryKey("PK_Traveller", x => x.PassportNumber);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Traveller_PassportNumber",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_volsVoyageurs_Traveller_PassengersPassportNumber",
                table: "volsVoyageurs");

            migrationBuilder.DropTable(
                name: "Traveller");

            migrationBuilder.AlterColumn<float>(
                name: "Salary",
                table: "Staff",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Function",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmployementDate",
                table: "Staff",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Staff",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passfirstname",
                table: "Staff",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passlastname",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TelNumber",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_volsVoyageurs_Staff_PassengersPassportNumber",
                table: "volsVoyageurs",
                column: "PassengersPassportNumber",
                principalTable: "Staff",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
