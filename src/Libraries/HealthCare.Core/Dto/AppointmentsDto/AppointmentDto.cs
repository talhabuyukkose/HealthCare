using HealthCare.Core.Domain.Enums;

namespace HealthCare.Core.Dto.AppointmentsDto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HospitalID { get; set; }
        public int MedicalUnitID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
