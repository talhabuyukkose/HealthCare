using HealthCare.Core.Domain.Common;

namespace HealthCare.Core.Domain.Entities
{
    public class MedicalUnit : BaseEntity
    {
        public string Name { get; set; }
        //ManytoMany
        public ICollection<HospitalMedicalUnit> HospitalMedicalUnits { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
