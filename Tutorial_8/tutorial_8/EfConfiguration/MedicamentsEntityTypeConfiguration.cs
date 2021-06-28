using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.Models;

namespace tutorial_8.EfConfiguration
{
    public class MedicamentsEntityTypeConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasData
                (
                    new Medicament
                    {
                        idMedicament = 1,
                        Name = "Aspirin",
                        Description = "Used to reduce pain, fever, or inflammation.",
                        Type = "Antipyretic"
                    },
                    new Medicament
                    {
                        idMedicament = 2,
                        Name = "Meprobamate",
                        Description = "Minor tranquilizer",
                        Type = "Tranqulizer"
                    },
                    new Medicament
                    {
                        idMedicament = 3,
                        Name = "Mevacor",
                        Description = "To treat high blood cholesterol and reduce the risk of cardiovascular disease",
                        Type = "Statin medication"
                    }
                );
        }
    }
}
