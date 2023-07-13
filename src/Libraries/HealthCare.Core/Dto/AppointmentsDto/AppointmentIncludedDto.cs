using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Dto.DoctorsDto;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Dto.MedicalUnitsDto;
using HealthCare.Core.Dto.Patients;

namespace HealthCare.Core.Dto.AppointmentsDto
{
    public class AppointmentIncludedDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public HospitalDto Hospital { get; set; }
        public int MedicalUnitID { get; set; }
        public MedicalUnitDto MedicalUnit { get; set; }
        public int DoctorID { get; set; }
        public DoctorDto Doctor { get; set; }
        public int PatientID { get; set; }
        public PatientDto Patient { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
