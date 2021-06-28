using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial_8.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "idPrescription", "Date", "DueDate", "IdPatient", "idDoctor" },
                values: new object[] { 1, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "idPrescription", "Date", "DueDate", "IdPatient", "idDoctor" },
                values: new object[] { 2, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "idPrescription", "Date", "DueDate", "IdPatient", "idDoctor" },
                values: new object[] { 3, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "idPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "idPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "idPrescription",
                keyValue: 3);
        }
    }
}
