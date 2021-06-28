using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.Models;

namespace tutorial_8.EfConfiguration
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData
            (
                new Patient { IdPatient = 1, FirstName = "Harvey", LastName = "Specter", BirthDate = new DateTime(1990, 06, 1) },
                new Patient { IdPatient = 2, FirstName = "Mike", LastName = "Ross", BirthDate = new DateTime(1991, 09, 11) },
                new Patient { IdPatient = 3, FirstName = "Louis", LastName = "Litt", BirthDate = new DateTime(1988, 04, 18) },
                new Patient { IdPatient = 4, FirstName = "Donna", LastName = "Pulsen", BirthDate = new DateTime(1994, 12, 13) }
            );
        }
    }
}
