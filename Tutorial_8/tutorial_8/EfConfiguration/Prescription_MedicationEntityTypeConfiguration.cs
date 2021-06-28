using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.Models;

namespace tutorial_8.EfConfiguration
{
    public class Prescription_MedicationEntityTypeConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => new { e.idPrescription, e.idMedicament });

            builder.HasData
                (
                new Prescription_Medicament
                {
                    idMedicament = 1,
                    idPrescription = 2,
                    Dose = 2,
                    Details = "XYZ"
                },
                new Prescription_Medicament
                {
                    idMedicament = 3,
                    idPrescription = 1,
                    Dose = 4,
                    Details = "ABC"
                },
                new Prescription_Medicament
                {
                    idMedicament = 1,
                    idPrescription = 1,
                    Dose = 4,
                    Details = "abc"
                }
                );
        }
    }
}
