using HealthCare.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthCare.Persistance.Context
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext(DbContextOptions options) : base(options)
        {
        }

        public PostgreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string appSettingPath = Directory.GetCurrentDirectory()
                .Replace("libraries", "Presentation")
                .Replace("Libraries", "Presentation")
                .Replace("persistance", "WebApi")
                .Replace("Persistance", "WebApi");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(appSettingPath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("PostgreDb");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
            });

            modelBuilder.Entity<MedicalUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
            });


            modelBuilder.Entity<HospitalMedicalUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.MedicalUnit).WithMany(many => many.HospitalMedicalUnits).HasForeignKey(e => e.MedicalUnitID);
                entity.HasOne(e => e.Hospital).WithMany(many => many.HospitalMedicalUnits).HasForeignKey(e => e.HospitalID);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.MedicalUnit).WithMany(many => many.Doctors).HasForeignKey(e => e.MedicalUnitID);
                entity.HasOne(e => e.Hospital).WithMany(many => many.Doctors).HasForeignKey(e => e.HospitalID);
            });



            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.HasOne(e => e.Hospital).WithMany(many => many.Appointments).HasForeignKey(key => key.HospitalID);
                entity.HasOne(e => e.MedicalUnit).WithMany(many => many.Appointments).HasForeignKey(key => key.MedicalUnitID);
                entity.HasOne(e => e.Doctor).WithMany(many => many.Appointments).HasForeignKey(key => key.DoctorID);
                entity.HasOne(e => e.Patient).WithMany(many => many.Appointments).HasForeignKey(key => key.PatientID);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
