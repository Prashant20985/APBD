using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial_8.Migrations
{
    public partial class AddesdMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Prescription_Medicament",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),//Made A mistake Earlier
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "idMedicament", "Description", "Name", "Type" },
                values: new object[] { 1, "Used to reduce pain, fever, or inflammation.", "Aspirin", "Antipyretic" });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "idMedicament", "Description", "Name", "Type" },
                values: new object[] { 2, "Minor tranquilizer", "Meprobamate", "Tranqulizer" });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "idMedicament", "Description", "Name", "Type" },
                values: new object[] { 3, "To treat high blood cholesterol and reduce the risk of cardiovascular disease", "Mevacor", "Statin medication" });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "idMedicament", "idPrescription", "Details", "Dose" },
                values: new object[] { 1, 2, "XYZ", 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "idMedicament", "idPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "abc", 4 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "idMedicament", "idPrescription", "Details", "Dose" },
                values: new object[] { 3, 1, "ABC", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "idMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "idMedicament", "idPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "idMedicament", "idPrescription" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "idMedicament", "idPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "idMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "idMedicament",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Details",
                table: "Prescription_Medicament",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
