using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.Models;

namespace tutorial_8.EfConfiguration
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasData
                (
                    new Prescription
                    {
                        idPrescription = 1,
                        Date = new DateTime(2021, 04, 04),
                        DueDate = new DateTime(2021, 04, 18),
                        IdPatient = 2,
                        idDoctor = 1
                    },
                    new Prescription
                    {
                        idPrescription = 2,
                        Date = new DateTime(2021, 04, 05),
                        DueDate = new DateTime(2021, 04, 22),
                        IdPatient = 3,
                        idDoctor = 2
                    },
                    new Prescription
                    {
                        idPrescription = 3,
                        Date = new DateTime(2021, 04, 04),
                        DueDate = new DateTime(2021, 04, 18),
                        IdPatient = 4,
                        idDoctor = 3
                    }
                );
        }
    }
}
