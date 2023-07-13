using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using HealthCare.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Persistance
{
    public static class ConfigureServices
    {
        public static void AddPersistanceConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("PostgreDb");

            services.AddDbContext<PostgreDbContext>
                (
                    conf =>
                    {
                        conf.UseNpgsql(connectionstring);
                        conf.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    }
                );

            services.AddTransient<IBaseRepository<Patient>, BaseRepository<Patient>>();
            services.AddTransient<IBaseRepository<MedicalUnit>, BaseRepository<MedicalUnit>>();
            services.AddTransient<IBaseRepository<HospitalMedicalUnit>, BaseRepository<HospitalMedicalUnit>>();
            services.AddTransient<IBaseRepository<Hospital>, BaseRepository<Hospital>>();
            services.AddTransient<IBaseRepository<Doctor>, BaseRepository<Doctor>>();
            services.AddTransient<IBaseRepository<Appointment>, BaseRepository<Appointment>>();

            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IMedicalUnitRepository, MedicalUnitRepository>();
            services.AddTransient<IHospitalRepository, HospitalRepository>();
            services.AddTransient<IDoctorRepository,DoctorRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

        }
    }
}
