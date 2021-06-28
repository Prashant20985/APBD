using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.Models;

namespace tutorial_8.EfConfiguration
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData
                (
                new Doctor { IdDoctor = 1, FirstName = "Walter", LastName = "White", Email = "ww@gamil.com" },
                new Doctor { IdDoctor = 2, FirstName = "Jesse", LastName = "Pinkman", Email = "jp@gmail.com" },
                new Doctor { IdDoctor = 3, FirstName = "Saul", LastName = "Goodman", Email = "sg@gamil.com" },
                new Doctor { IdDoctor = 4, FirstName = "Gus", LastName = "Fring", Email = "gusf@gamil.com" }
                );
        }
    }
}
