using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.EfConfiguration;
using tutorial_8.Models.Authentication;

namespace tutorial_8.Models
{
    public class Clinic_DbContext : DbContext
    {
        public Clinic_DbContext()
        {

        }

        public Clinic_DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Prescription_MedicationEntityTypeConfiguration());

        }
    }
}
