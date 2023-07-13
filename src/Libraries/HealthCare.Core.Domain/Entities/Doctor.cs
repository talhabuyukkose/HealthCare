using HealthCare.Core.Domain.Common;

namespace HealthCare.Core.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int MedicalUnitID { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
