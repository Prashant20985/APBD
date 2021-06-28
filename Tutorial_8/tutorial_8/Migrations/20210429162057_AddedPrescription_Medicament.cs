using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial_8.Migrations
{
    public partial class AddedPrescription_Medicament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    idMedicament = table.Column<int>(type: "int", nullable: false),
                    idPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.idPrescription, x.idMedicament });
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Medicament_idMedicament",
                        column: x => x.idMedicament,
                        principalTable: "Medicament",
                        principalColumn: "idMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Prescription_idPrescription",
                        column: x => x.idPrescription,
                        principalTable: "Prescription",
                        principalColumn: "idPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_idMedicament",
                table: "Prescription_Medicament",
                column: "idMedicament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");
        }
    }
}
