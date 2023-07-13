using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Dto.AppointmentsDto;
using HealthCare.Core.Dto.HospitalsDto;
using HealthCare.Core.Dto.MedicalUnitsDto;

namespace HealthCare.Core.Dto.DoctorsDto
{
    public class DoctorIncludedDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int MedicalUnitID { get; set; }
        public MedicalUnitDto MedicalUnit { get; set; }
        public int HospitalID { get; set; }
        public HospitalDto Hospital { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
