using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial_8.Migrations
{
    public partial class AddedDataInPatientAndDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "ww@gamil.com", "Walter", "White" },
                    { 2, "jp@gmail.com", "Jesse", "Pinkman" },
                    { 3, "sg@gamil.com", "Saul", "Goodman" },
                    { 4, "gusf@gamil.com", "Gus", "Fring" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harvey", "Specter" },
                    { 2, new DateTime(1991, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", "Ross" },
                    { 3, new DateTime(1988, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Louis", "Litt" },
                    { 4, new DateTime(1994, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donna", "Pulsen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4);
        }
    }
}
